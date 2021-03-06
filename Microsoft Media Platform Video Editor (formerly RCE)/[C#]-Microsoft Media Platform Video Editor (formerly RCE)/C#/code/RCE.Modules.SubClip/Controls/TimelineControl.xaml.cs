// <copyright file="TimelineControl.xaml.cs" company="Microsoft Corporation">
// ===============================================================================
//
//
// Project: Microsoft Silverlight Rough Cut Editor
// FILES: TimelineControl.xaml.cs                     
//
// ===============================================================================
// Copyright 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================
// </copyright>

namespace RCE.Modules.SubClip.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using Microsoft.Practices.Composite.Events;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.SilverlightMediaFramework.Plugins.Primitives;
    using RCE.Infrastructure;
    using RCE.Infrastructure.Events;
    using RCE.Infrastructure.Models;
    using RCE.Infrastructure.Services;
    using RCE.Modules.SubClip.Models;
    using SMPTETimecode;

    /// <summary>
    /// A timeline control.
    /// </summary>
    public partial class TimelineControl : UserControl, IDisposable
    {
        /// <summary>
        /// Default zoom value.
        /// </summary>
        private const double ZoomValue = 2;

        /// <summary>
        /// Minimum zoom slider size.
        /// </summary>
        private const int MinimumZoomSliderSize = 2;

        /// <summary>
        /// Minimum zoom duration in seconds.
        /// </summary>
        private const double MinimumZoomDurationInSeconds = 60;

        /// <summary>
        /// Contains the main bar markers of the timeline.
        /// </summary>
        private readonly List<Line> mainBarMarkers;

        /// <summary>
        /// Contains the top bar markers of the timeline.
        /// </summary>
        private readonly List<Line> topBarMarkers;

        /// <summary>
        /// Contains the top bar labels of the timeline.
        /// </summary>
        private readonly List<TextBlock> topBarLabels;

        private readonly IEventAggregator eventAggregator;

        private readonly bool snapToFragmentBoundaries;

        /// <summary>
        /// Contains the subclip marks.
        /// </summary>
        private readonly IDictionary<ScrubShiftType, Rectangle> subClipMarks;

        /// <summary>
        /// Flag to show fragment boundaries or not.
        /// </summary>
        private bool showFragmentBoundaries;

        /// <summary>
        /// Timer to manage thumbnail preview.
        /// </summary>
        private DispatcherTimer thumbTimer;

        /// <summary>
        /// Main marker brush.
        /// </summary>
        private SolidColorBrush mainMarkerStroke;

        /// <summary>
        /// Top marker brush.
        /// </summary>
        private SolidColorBrush topMarkerStroke;

        /// <summary>
        /// The foreground color of the top time marks
        /// </summary>
        private SolidColorBrush topTimeMarkForeground;

        /// <summary>
        /// The timeline duration.
        /// </summary>
        private TimeCode duration;

        /// <summary>
        /// The slope to calculate the zoom duration according to the zoom slider size.
        /// </summary>
        private double zoomDurationSlope;

        /// <summary>
        /// The y-intercep to calculate the zoom duration according to the zoom slider size.
        /// </summary>
        private double zoomDurationInterceptInSeconds;

        /// <summary>
        /// The start position of the timeline.
        /// </summary>
        private TimeCode viewStartPosition;

        /// <summary>
        /// The end position of the timeline.
        /// </summary>
        private TimeCode viewEndPosition;

        /// <summary>
        /// Determines whether the playhead is being moved or not. 
        /// </summary>
        private bool movingPlayhead;

        /// <summary>
        /// The current position of the timeline.
        /// </summary>
        private TimeCode currentPosition;

        /// <summary>
        /// Last known position of the mouse.
        /// </summary>
        private double lastKnownMousePosition;

        /// <summary>
        /// The active zoom handler.
        /// </summary>
        private ZoomSliderHandler activeZoomHandler;

        private TimeCode availableTime;

        private bool isMoving;
        private TimeSpan lastKnownTimeSpan;

        private bool disposed;

        private DispatcherTimer hidePreviewTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimelineControl"/> class.
        /// </summary>
        public TimelineControl()
        {
            InitializeComponent();

            this.TopBar.MouseLeftButtonDown += this.TimeBar_MouseLeftButtonDown;
            this.HorizontalAvailableBar.MouseLeftButtonDown += this.TimeBar_MouseLeftButtonDown;

            this.TopBar.MouseEnter += new MouseEventHandler(this.ThumbnailPreview_MouseEnter);
            this.HorizontalAvailableBar.MouseEnter += new MouseEventHandler(this.ThumbnailPreview_MouseEnter);

            this.TopBar.MouseLeave += new MouseEventHandler(this.ThumbnailPreview_MouseLeave);
            this.HorizontalAvailableBar.MouseLeave += new MouseEventHandler(this.ThumbnailPreview_MouseLeave);

            this.TopBar.MouseMove += new MouseEventHandler(this.ThumbnailPreview_MouseMove);
            this.HorizontalAvailableBar.MouseMove += new MouseEventHandler(this.ThumbnailPreview_MouseMove);

            this.MouseLeave += new MouseEventHandler(this.ThumbnailPreview_MouseLeave);

            this.Playhead.MouseLeftButtonDown += this.TimeBar_MouseLeftButtonDown;
            this.ZoomSliderRightHandler.MouseLeftButtonDown += this.ZoomSliderRightHandler_MouseLeftButtonDown;
            this.ZoomSliderLeftHandler.MouseLeftButtonDown += this.ZoomSliderLeftHandler_MouseLeftButtonDown;
            this.ZoomSliderMiddleHandler.MouseLeftButtonDown += this.ZoomSliderMiddleHandler_MouseLeftButtonDown;
            this.SizeChanged += this.TimelineControl_SizeChanged;

            this.mainBarMarkers = new List<Line>();
            this.topBarMarkers = new List<Line>();
            this.topBarLabels = new List<TextBlock>();
            this.subClipMarks = new Dictionary<ScrubShiftType, Rectangle>();

            this.mainMarkerStroke = (SolidColorBrush)this.Resources["MainMarkerStroke"];
            this.topMarkerStroke = (SolidColorBrush)this.Resources["TimelineControlTopRulerStroke"];
            this.topTimeMarkForeground = (SolidColorBrush)this.Resources["TimelineControlTopTimeMarkForeground"];

            Application.Current.RootVisual.MouseMove += RootVisualMouseMove;

            // Key Commands
            if (Application.Current.RootVisual != null)
            {
                Application.Current.RootVisual.KeyDown += this.RootVisual_KeyDown;
            }

            if (!DesignerProperties.IsInDesignMode)
            {
                this.eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

                var configurationSerive = ServiceLocator.Current.GetInstance<IConfigurationService>();
                if (configurationSerive != null)
                {
                    this.snapToFragmentBoundaries = configurationSerive.GetSnapToFragmentBoundaries();
                }
            }

            this.thumbTimer = new DispatcherTimer();
            this.thumbTimer.Interval = TimeSpan.FromMilliseconds(750);
            this.thumbTimer.Tick += this.ThumbTimer_Tick;
        }

        /// <summary>
        /// Occurs when the position of the playhead change.
        /// </summary>
        public event EventHandler<PositionChangeEventArgs> PositionChange;

        /// <summary>
        /// Occurs when the playhead is being moved.
        /// </summary>
        public event EventHandler MovingPlayHead;

        /// <summary>
        /// Occurs when the control is being resized.
        /// </summary>
        public event EventHandler Resized;

        /// <summary>
        /// Defines the slider handlers that are available.
        /// </summary>
        private enum ZoomSliderHandler
        {
            /// <summary>
            /// No handler selected.
            /// </summary>
            None = 0,

            /// <summary>
            /// Left handler selected.
            /// </summary>
            Left = 1,

            /// <summary>
            /// Middle handler selected.
            /// </summary>
            Middle = 2,

            /// <summary>
            /// Right handler selected.
            /// </summary>
            Right = 3
        }

        /// <summary>
        /// Defines the range of zoom options that are available.
        /// </summary>
        private enum Zoom
        {
            /// <summary>
            /// Represents the In zoom.
            /// </summary>
            In,

            /// <summary>
            /// Represents the Out zoom.
            /// </summary>
            Out
        }

        /// <summary>
        /// Gets or sets the media element.
        /// </summary>
        /// <value>The media element.</value>
        public IRCESmoothStreamingMediaPlugin MediaPlugin { get; set; }

        /// <summary>
        /// Gets or sets the start position of the timeline.
        /// </summary>
        /// <value>A value indicating the start position of the timeline.</value>
        public TimeCode ViewStartPosition
        {
            get
            {
                return this.viewStartPosition;
            }

            set
            {
                this.viewStartPosition = value;
                this.ValidateViewPositions();
                this.RefreshZoomSlider();
                this.RefreshTimeMarks();
                this.RefreshElements();
                this.RefreshSubClipMarks();
                this.UpdateTime();
            }
        }

        /// <summary>
        /// Gets or sets a flag to show fragment boundaries or not.
        /// </summary>
        public bool ShowFragmentBoundaries
        {
            get { return this.showFragmentBoundaries; }

            set
            {
                if (this.showFragmentBoundaries != value)
                {
                    this.showFragmentBoundaries = value;
                    this.RefreshLayersMargin();
                    this.RefreshTimeMarks();
                    this.RefreshElements();
                    this.RefreshSubClipMarks();
                    this.UpdateTime();
                }
            }
        }

        /// <summary>
        /// Gets or sets the end position of the timeline.
        /// </summary>
        /// <value>A value indicating the end position of the timeline.</value>
        public TimeCode ViewEndPosition
        {
            get
            {
                return this.viewEndPosition;
            }

            set
            {
                this.viewEndPosition = value;
                this.ValidateViewPositions();
                this.RefreshZoomSlider();
                this.RefreshTimeMarks();
                this.RefreshElements();
                this.RefreshSubClipMarks();
                this.DownloadProgressBar.Refresh(this.TimelineGrid.ActualWidth / (this.ViewEndPosition.TotalSeconds - this.ViewStartPosition.TotalSeconds) * this.duration.TotalSeconds);
                this.UpdateTime();
            }
        }

        /// <summary>
        /// Gets the Mark In position.
        /// </summary>
        /// <value>The Mark In position.</value>
        public TimeCode InPosition
        {
            get
            {
                if (this.subClipMarks.ContainsKey(ScrubShiftType.In))
                {
                    return (TimeCode)this.subClipMarks[ScrubShiftType.In].Tag;
                }

                return this.StartOffset;
            }
        }

        /// <summary>
        /// Gets the Mark Out position.
        /// </summary>
        /// <value>The  Mark Out position.</value>
        public TimeCode OutPosition
        {
            get
            {
                if (this.subClipMarks.ContainsKey(ScrubShiftType.Out))
                {
                    return (TimeCode)this.subClipMarks[ScrubShiftType.Out].Tag;
                }

                return this.StartOffset.TotalSeconds > 0 ? this.duration + this.StartOffset : this.duration;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a Mark In exists or not.
        /// </summary>
        /// <value>A true when the Mark In exists;otherwise false.</value>
        public bool HasMarkIn
        {
            get { return this.subClipMarks.ContainsKey(ScrubShiftType.In); }
        }

        /// <summary>
        /// Gets a value indicating whether a Mark Out exists or not.
        /// </summary>
        /// <value>A true when the Mark Out exists;otherwise false.</value>
        public bool HasMarkOut
        {
            get { return this.subClipMarks.ContainsKey(ScrubShiftType.Out); }
        }

        /// <summary>
        /// Gets the current position of the timeline.
        /// </summary>
        /// <value>A value indicating the current position of the timeline.</value>
        public TimeCode CurrentPosition
        {
            get { return this.currentPosition; }
        }

        /// <summary>
        /// Gets the current duration of the timeline.
        /// </summary>
        /// <value>A value indicating the current duration of the timeline.</value>
        public TimeCode Duration
        {
            get { return this.duration; }
        }

        /// <summary>
        /// Gets the start timecode offset used by the timeline.
        /// </summary>
        /// <value>The start offset of the timeline.</value>
        public TimeCode StartOffset { get; private set; }

        public Asset Asset { get; set; }

        /// <summary>
        /// Sets the playhead position to the given timecode.
        /// </summary>
        /// <param name="timeCode">The new position of the playhead.</param>
        public void SetPlayHeadPosition(TimeCode timeCode)
        {
            // timeCode should not include start offset when SetPlayHeadPosition is called
            ////if (timeCode >= this.StartOffset)
            ////{
            ////    timeCode = timeCode - this.StartOffset;
            ////}

            if (timeCode > this.duration)
            {
                timeCode = this.duration;
            }

            this.currentPosition = timeCode + this.StartOffset;

            var totalSeconds = this.duration.TotalSeconds;
            var visibleSeconds = this.viewEndPosition.TotalSeconds - this.viewStartPosition.TotalSeconds;

            if (visibleSeconds == 0)
            {
                visibleSeconds = 1;
            }

            var startSecond = this.viewStartPosition.TotalSeconds;
            var layersWidth = this.TimelineGrid.ActualWidth;
            var markerOffset = layersWidth / visibleSeconds;
            var newPosition = markerOffset * startSecond;

            this.PlayheadCanvas.Width = (this.TimelineGrid.ActualWidth / visibleSeconds) * totalSeconds;
            this.PlayheadCanvas.Margin = new Thickness(-newPosition, 0, 0, 0);

            double x = this.TimeCodeToPixel(timeCode);
            Canvas.SetLeft(this.Playhead, x);

            double width = x - newPosition;

            width = Math.Max(0, width);

            this.TopBar.Width = width;
        }

        /// <summary>
        /// Sets the duration of the timeline and resets the zoom.
        /// </summary>
        /// <param name="value">The duration.</param>
        public void SetDuration(TimeCode value)
        {
            this.duration = value;

            // Calculate the minimum size of the zoom slider.
            var minZoomSize = MinimumZoomSliderSize + this.ZoomSliderLeftHandler.Width + this.ZoomSliderRightHandler.Width;

            // Calculate the timeline duration for the minimum zoom slider size for the current duration.
            var minZoomDurationInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * minZoomSize;

            // Calculate the available duration that can be used for zooming.
            var availableZoomDurationInSeconds = this.duration.TotalSeconds - MinimumZoomDurationInSeconds;

            if ((availableZoomDurationInSeconds > 0) && (minZoomDurationInSeconds > MinimumZoomDurationInSeconds))
            {
                // Caculate the available slider size that can be used for zooming.
                var availableZoomSize = this.TimelineGrid.Width - minZoomSize;

                // Calculate the slope and intercept of the zoom duration function.
                this.zoomDurationSlope = (availableZoomDurationInSeconds / availableZoomSize);
                this.zoomDurationInterceptInSeconds = this.duration.TotalSeconds - (this.zoomDurationSlope * this.TimelineGrid.Width);
            }
            else
            {
                this.zoomDurationSlope = 0;
                this.zoomDurationInterceptInSeconds = 0;
            }

            this.ResetZoom();
            this.eventAggregator.GetEvent<DurationChangedEvent>().Publish(new DurationChangedEventArgs(value));
        }

        /// <summary>
        /// Sets the available time of the timeline.
        /// </summary>
        /// <param name="timeCode">The available time.</param>
        public void SetAvailableTime(TimeCode timeCode)
        {
            this.availableTime = timeCode;
            var visibleFrames = this.viewEndPosition.TotalFrames - this.viewStartPosition.TotalFrames;

            if (visibleFrames == 0)
            {
                visibleFrames = 1;
            }

            var startFrame = this.viewStartPosition.TotalFrames;

            var layersWidth = this.TimelineGrid.ActualWidth;
            var markerOffset = layersWidth / visibleFrames;
            var newPosition = markerOffset * startFrame;
            double x = this.TimeCodeToPixel(timeCode);

            double width = x - newPosition;

            width = Math.Min(this.TimelineGrid.ActualWidth, width);
            width = Math.Max(0, width);

            this.HorizontalAvailableBar.Width = width;
        }

        /// <summary>
        /// Sets the start offset Timecode of the timeline.
        /// </summary>
        /// <param name="startOffset">The new start offset timecode.</param>
        public void SetStartOffsetTimeCode(TimeCode startOffset)
        {
            this.StartOffset = startOffset;
            this.ResetZoom();

            if (this.currentPosition >= startOffset && startOffset.TotalSeconds > 0)
            {
                this.SetPlayHeadPosition(this.currentPosition - startOffset);
            }
            else
            {
                this.SetPlayHeadPosition(new TimeCode(0, SmpteFrameRate.Smpte2398));
            }
        }

        /// <summary>
        /// Sets the mark in to the given position. Replaces any existing mark in.
        /// </summary>
        /// <param name="position">The position used as mark in.</param>
        /// <returns>The new mark in position if it was snapped to a chunk boundary.</returns>
        public TimeCode SetMarkIn(TimeCode position)
        {
            if (this.snapToFragmentBoundaries)
            {
                position = this.GetPositionWithoutStartOffset(position);
                position = this.SnapToChunk(position, SnapMode.Left);
            }

            this.DepurateMarkOut(position);

            this.RemoveSubClipMark(ScrubShiftType.In);
            this.AddSubClipMark(ScrubShiftType.In, position, Colors.Green);

            return position;
        }

        /// <summary>
        /// Removes the MarkIn.
        /// </summary>
        public void RemoveMarkIn()
        {
            this.RemoveSubClipMark(ScrubShiftType.In);
        }

        /// <summary>
        /// Removes the MarkOut.
        /// </summary>
        public void RemoveMarkOut()
        {
            this.RemoveSubClipMark(ScrubShiftType.Out);
        }

        /// <summary>
        /// Sets the mark out to the given position. Replaces any existing mark out.
        /// </summary>
        /// <param name="position">The position used as mark out.</param>
        /// <returns>The new mark out position if it was snapped to a chunk boundary.</returns>
        public TimeCode SetMarkOut(TimeCode position)
        {
            if (this.snapToFragmentBoundaries)
            {
                position = this.GetPositionWithoutStartOffset(position);
                position = this.SnapToChunk(position, SnapMode.Right);
            }

            this.DepurateMarkIn(position);

            this.RemoveSubClipMark(ScrubShiftType.Out);
            this.AddSubClipMark(ScrubShiftType.Out, position, Colors.Yellow);

            return position;
        }

        /// <summary>
        /// Validates if key strokes can be handled or not.
        /// </summary>
        /// <param name="originalSource">The source of the key stroke.</param>
        /// <returns>A true if the key stroke can be handled, otherwise false.</returns>
        public bool CanHandleKeyStroke(object originalSource)
        {
            ContentControl contentControl = originalSource as ContentControl;

            bool handleKey = (originalSource is TimelineControl) ||
                            (contentControl != null &&
                             contentControl.Name.ToUpper(CultureInfo.InvariantCulture).StartsWith("SUBCLIPPLAYHEAD"));

            return handleKey;
        }

        public void GoToPosition(TimeCode timecode)
        {
            this.SetPlayHeadPosition(timecode);

            this.OnPositionChange(this.currentPosition);
        }

        /// <summary>
        /// Resets the slider zoom and refreshes the time marks and elements based on the new zoom.
        /// </summary>
        public void ResetZoom()
        {
            this.viewStartPosition = TimeCode.FromAbsoluteTime(0, this.duration.FrameRate);
            this.viewEndPosition = this.duration;
            this.RefreshZoomSlider();
            this.RefreshTimeMarks();
            this.RefreshElements();
            this.RefreshSubClipMarks();
            this.DownloadProgressBar.Refresh(this.TimelineGrid.ActualWidth / (this.ViewEndPosition.TotalSeconds - this.ViewStartPosition.TotalSeconds) * this.duration.TotalSeconds);
            this.UpdateTime();
        }

        /// <summary>
        /// Zooms the timeline.
        /// </summary>
        /// <param name="delta">The delta that determines if the zoom should be in or out.</param>
        public void ZoomTimeline(double delta)
        {
            this.HideThumbnail();

            if (delta > 0)
            {
                this.ZoomHandler(Zoom.In, 10);
            }
            else if (delta < 0)
            {
                this.ZoomHandler(Zoom.Out, 10);
            }

            this.isMoving = false;
        }

        /// <summary>
        /// Gets a position without the start offset.
        /// </summary>
        /// <param name="timeCode">The initial position.</param>
        /// <returns>The initial position without the start offset.</returns>
        public TimeCode GetPositionWithoutStartOffset(TimeCode timeCode)
        {
            TimeCode result = timeCode;

            if (result >= this.StartOffset)
            {
                result = result - this.StartOffset;
            }

            return result;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void UpdateDownloadProgress(double progress, double offset)
        {
            this.DownloadProgressBar.ReportProgress(progress, offset, this.TimelineGrid.ActualWidth / (this.ViewEndPosition.TotalSeconds - this.ViewStartPosition.TotalSeconds) * this.duration.TotalSeconds);
        }

        public void UpdateDownloadProgress(IDictionary<double, double> progress)
        {
            this.DownloadProgressBar.ClearProgress();
            foreach (double key in progress.Keys)
            {
                this.DownloadProgressBar.ReportProgress(key, progress[key], this.TimelineGrid.ActualWidth / (this.ViewEndPosition.TotalSeconds - this.ViewStartPosition.TotalSeconds) * this.duration.TotalSeconds);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Indicates if Dispose is being called from the Dispose method.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !this.disposed)
            {
                if (this.ThumbnailImage != null)
                {
                    this.ThumbnailImage.Dispose();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Creates a mark line for the timeline.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="h">The height.</param>
        /// <param name="stroke">The stroke of the line.</param>
        /// <returns>The line created using the parameters.</returns>
        private static Line CreateMark(double x, double y, double h, Brush stroke)
        {
            var l = new Line
            {
                X1 = x,
                X2 = x,
                Y1 = y,
                Y2 = y + h,
                Stroke = stroke,
                StrokeThickness = 1,
                UseLayoutRounding = true
            };

            return l;
        }

        /// <summary>
        /// Gets a string representation of a <seealso cref="TimeCode"/>.
        /// </summary>
        /// <param name="timecode">The timecode being used.</param>
        /// <returns>A string representation of the timecode.</returns>
        private static string GetTimeString(TimeCode timecode)
        {
            var hoursString = timecode.HoursSegment.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            var minutesString = timecode.MinutesSegment.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            var secondsString = timecode.SecondsSegment.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

            return string.Format(CultureInfo.InvariantCulture, "{0}:{1}:{2}", hoursString, minutesString, secondsString);
        }

        /// <summary>
        /// Snaps the position to the nearest chunk.
        /// </summary>
        private TimeCode SnapToChunk(TimeCode position, SnapMode snapMode)
        {
            if (this.snapToFragmentBoundaries && this.Asset != null && this.Asset.IsAdaptiveAsset)
            {
                var currentSegment = this.MediaPlugin.CurrentSegment;
                if (currentSegment != null)
                {
                    var firstVideoStream = currentSegment.SelectedStreams.Where(s => s.Type == StreamType.Video).FirstOrDefault();
                    if (firstVideoStream != null)
                    {
                        var timeScale = firstVideoStream.TimeScale.HasValue ? firstVideoStream.TimeScale.Value.Ticks : 10000000;
                        var decimalsTrim = timeScale.ToString().Length - 1;
                        var relativePosition = Math.Round(Convert.ToDouble(position.TotalSecondsPrecision) + firstVideoStream.GetStartOffset().TotalSeconds, decimalsTrim);
                        var chunks = firstVideoStream.DataChunks.FindChunks((t, d) => relativePosition >= Math.Round(t, decimalsTrim) && relativePosition <= Math.Round(t + d, decimalsTrim));

                        Tuple<double, double> chunk = null;
                        chunk = chunks.FirstOrDefault();

                        if (chunks.Count() > 1)
                        {
                            snapMode = SnapMode.Nearest;
                        }

                        if (chunk != null)
                        {
                            decimal newTime = 0;

                            switch (snapMode)
                            {
                                case SnapMode.Left:
                                    newTime = Convert.ToDecimal(chunk.Item1 * timeScale) / timeScale;
                                    break;
                                case SnapMode.Right:
                                    newTime = Convert.ToDecimal((chunk.Item1 * timeScale) + (chunk.Item2 * timeScale)) / timeScale;
                                    break;
                                case SnapMode.Nearest:
                                    newTime = Math.Abs(chunk.Item1 - relativePosition) < Math.Abs(chunk.Item1 + chunk.Item2 - relativePosition)
                                        ? Convert.ToDecimal(chunk.Item1 * timeScale) / timeScale
                                        : Convert.ToDecimal((chunk.Item1 * timeScale) + (chunk.Item2 * timeScale)) / timeScale;
                                    break;
                            }

                            return new TimeCode(newTime, position.FrameRate);
                        }
                    }
                }
            }

            return position;
        }

        /// <summary>
        /// Mouse enter event to manage thumbnail preview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThumbnailPreview_MouseEnter(object sender, MouseEventArgs e)
        {
            this.thumbTimer.Start();
        }

        /// <summary>
        /// Mouse move event to manage thumbnail preview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThumbnailPreview_MouseMove(object sender, MouseEventArgs e)
        {
            this.HashMark.Visibility = Visibility.Visible;
            this.isMoving = true;

            ////this.HideThumbnail();

            var x = e.GetPosition(this.VideoLayerCanvas).X;

            var timecode = this.PixelToTimeCode(x);

            timecode = timecode.TotalSecondsPrecision < 0 ? TimeCode.FromAbsoluteTime(0, timecode.FrameRate) : timecode;

            if (timecode > this.duration)
            {
                timecode = this.duration;
            }

            timecode = timecode + this.StartOffset;

            this.lastKnownTimeSpan = TimeSpan.FromSeconds(timecode.TotalSeconds);

            this.SetTooltipPosition(x);

            this.isMoving = false;
        }

        /// <summary>
        /// Mouse leave event to manage thumbnail preview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThumbnailPreview_MouseLeave(object sender, MouseEventArgs e)
        {
            this.thumbTimer.Stop();

            this.HideThumbnail();
        }

        /// <summary>
        /// Tick event to manage Thumbnail Preview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThumbTimer_Tick(object sender, EventArgs e)
        {
            if (!this.isMoving)
            {
                if (this.hidePreviewTimer == null)
                {
                    this.hidePreviewTimer = new DispatcherTimer();
                    this.hidePreviewTimer.Interval = new TimeSpan(0, 0, 6);
                    this.hidePreviewTimer.Tick += HidePreviewTimerTick;
                }

                this.hidePreviewTimer.Start();

                this.ThumbnailImage.ShowThumb(this.Asset.Source, this.Asset.IsAdaptiveAsset, this.lastKnownTimeSpan);
            }

            this.isMoving = true;
        }

        private void RootVisualMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.ThumbnailImage.IsShowing)
            {
                var mousePosition = e.GetPosition(null);
                var elems = VisualTreeHelper.FindElementsInHostCoordinates(mousePosition, (UIElement)sender);

                if (!elems.Contains(this))
                {
                    this.HideThumbnail();
                }
            }
        }

        private void HidePreviewTimerTick(object sender, EventArgs e)
        {
            this.HideThumbnail();
        }

        /// <summary>
        /// Hide Thumbnail.
        /// </summary>
        private void HideThumbnail()
        {
            this.ThumbnailImage.HideThumb();
            this.HashMark.Visibility = Visibility.Collapsed;

            if (this.hidePreviewTimer != null)
            {
                this.hidePreviewTimer.Stop();
            }
        }

        /// <summary>
        /// Calculate position and size according the mouse pointer position.
        /// </summary>
        /// <param name="x"></param>
        private void SetTooltipPosition(double x)
        {
            Canvas.SetLeft(this.HashMark, x);

            double start = this.TimeCodeToPixel(this.ViewStartPosition);
            x = x - start - (112 / 2);

            if (x < 0)
            {
                x = 0;
            }

            this.ToolTip.HorizontalOffset = x;
        }

        /// <summary>
        /// Refreshes the zoom slider.
        /// </summary>
        private void RefreshZoomSlider()
        {
            if (this.TimelineGrid.ActualWidth <= 0 || this.duration.TotalSeconds <= 0)
            {
                return;
            }

            var modifier = this.TimelineGrid.ActualWidth / this.duration.TotalSeconds;
            var x1 = this.ViewStartPosition.TotalSeconds * modifier;
            var x2 = this.ViewEndPosition.TotalSeconds * modifier;

            Canvas.SetLeft(this.ZoomSliderLeftHandler, x1);
            Canvas.SetLeft(this.ZoomSliderRightHandler, x2 - this.ZoomSliderRightHandler.ActualWidth);

            this.RefreshZoomSliderMiddleHandler();
        }

        /// <summary>
        /// Refreshes the zoom slider middle handler.
        /// </summary>
        private void RefreshZoomSliderMiddleHandler()
        {
            Canvas.SetLeft(this.ZoomSliderMiddleHandler, Canvas.GetLeft(this.ZoomSliderLeftHandler) + this.ZoomSliderLeftHandler.ActualWidth);

            var width = Canvas.GetLeft(this.ZoomSliderRightHandler) - Canvas.GetLeft(this.ZoomSliderMiddleHandler);

            if (width <= 0)
            {
                width = MinimumZoomSliderSize;
            }

            this.ZoomSliderMiddleHandler.Width = width;
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the TimeBar. Notifies about the playhead moves and raises the TopBarDoubleClicked event when applies. 
        /// Attaches to root visual events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void TimeBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.OnMovingPlayhead();

            // TODO: Avoid having to use RootVisual
            if (!this.movingPlayhead)
            {
                Application.Current.RootVisual.MouseMove += this.TimeBar_MouseMove;
                this.movingPlayhead = true;
                this.SubClipPlayheadContentControl.Focus();
            }

            Application.Current.RootVisual.MouseLeftButtonUp += this.TimeBar_MouseLeftButtonUp;
            this.TimeBar_MouseMove(sender, e);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the MouseMove event of the TimeBar. Notifies about the position change.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void TimeBar_MouseMove(object sender, MouseEventArgs e)
        {
            var x = e.GetPosition(this.VideoLayerCanvas).X;

            var timecode = this.PixelToTimeCode(x);

            timecode = timecode.TotalSecondsPrecision < 0 ? TimeCode.FromAbsoluteTime(0, timecode.FrameRate) : timecode;
            if (this.snapToFragmentBoundaries)
            {
                timecode = this.SnapToChunk(timecode, SnapMode.Nearest);
                timecode = this.GetPositionWithoutStartOffset(timecode);
            }

            this.SetPlayHeadPosition(timecode);
        }

        /// <summary>
        /// Converts a pixel into a timecode representation.
        /// </summary>
        /// <param name="px">The pixel being converted.</param>
        /// <returns>The timecode representation of the pixel.</returns>
        private TimeCode PixelToTimeCode(double px)
        {
            return TimeCode.FromAbsoluteTime((this.duration.TotalSeconds * px) / this.VideoLayerCanvas.ActualWidth, this.duration.FrameRate);
        }

        /// <summary>
        /// Handles the MouseLeftButtonUp event of the TimeBar. Detaches from the root visual events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void TimeBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var x = e.GetPosition(this.VideoLayerCanvas).X;

            var timecode = this.PixelToTimeCode(x);

            timecode = timecode.TotalSecondsPrecision < 0 ? TimeCode.FromAbsoluteTime(0, timecode.FrameRate) : timecode;
            if (this.snapToFragmentBoundaries)
            {
                timecode = this.SnapToChunk(timecode, SnapMode.Nearest);
                timecode = this.GetPositionWithoutStartOffset(timecode);
            }

            this.GoToPosition(timecode);

            Application.Current.RootVisual.MouseMove -= this.TimeBar_MouseMove;
            Application.Current.RootVisual.MouseLeftButtonUp -= this.TimeBar_MouseLeftButtonUp;
            this.movingPlayhead = false;
            e.Handled = true;
        }

        /// <summary>
        /// Refreshes layers margins.
        /// </summary>
        private void RefreshLayersMargin()
        {
            var totalTime = this.duration.TotalSeconds;
            var visibleTime = this.viewEndPosition.TotalSeconds - this.viewStartPosition.TotalSeconds;

            if (visibleTime == 0)
            {
                visibleTime = 1;
            }

            ////if (visibleTime < 0)
            ////{
            ////    visibleTime += this.StartOffset.TotalSeconds;
            ////}

            ////var startTime = this.viewStartPosition.TotalSeconds;

            ////var layersWidth = this.TimelineGrid.ActualWidth;
            //// var markerOffset = visibleTime != 0 ? layersWidth / visibleTime : 0;
            ////var newPosition = markerOffset * startTime;
            ////this.VideoLayerCanvas.Width = (this.TimelineGrid.ActualWidth / visibleTime) * totalTime;
            ////var layersMargin = new Thickness(-newPosition, 0, 0, 0);

            var startTime = this.viewStartPosition.TotalSeconds;

            var layersWidth = this.TimelineGrid.ActualWidth;
            var markerOffset = layersWidth / visibleTime;
            var newPosition = markerOffset * startTime;
            this.VideoLayerCanvas.Width = (this.TimelineGrid.ActualWidth / visibleTime) * totalTime;
            var layersMargin = new Thickness(-newPosition, 0, 0, 0);

            this.VideoLayerCanvas.Margin = layersMargin;
            this.TimeMarksCanvas.Margin = layersMargin;
            this.MarkInOutLayerCanvas.Margin = layersMargin;
            this.DownloadProgressBar.Margin = layersMargin;
            this.SubClipComments.Margin = layersMargin;
        }

        /// <summary>
        /// Refreshs the subclip marks.
        /// </summary>
        private void RefreshSubClipMarks()
        {
            foreach (Rectangle rectangle in this.subClipMarks.Values)
            {
                TimeCode position = (TimeCode)rectangle.Tag;

                TimeCode timeCode = this.GetPositionWithoutStartOffset(position);

                double x = this.TimeCodeToPixel(timeCode);
                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, 0d);
            }
        }

        /// <summary>
        /// Refreshes the time marks.
        /// </summary>
        private void RefreshTimeMarks()
        {
            if (double.IsNaN(this.TimelineGrid.ActualWidth) || this.TimelineGrid.ActualWidth <= 0 ||
                this.ViewStartPosition >= this.ViewEndPosition || this.duration.TotalSeconds <= 0)
            {
                return;
            }

            // Get time values
            var totalTime = TimeCode.FromFrames(this.duration.TotalFrames + 1, this.duration.FrameRate).TotalSeconds;
            var visibleTime = this.viewEndPosition.TotalSeconds - this.viewStartPosition.TotalSeconds;

            // Get max widths and heights
            var layersTop = this.TopBar.ActualHeight;

            // var layersHeight = this.VideoBar.ActualHeight + this.AudioBar.ActualHeight + 4;
            var layersWidth = this.TimelineGrid.ActualWidth;
            var markerOffset = layersWidth / visibleTime;

            // Marks position
            this.TimeMarksCanvas.Height = layersTop;

            // ix, start/end, 1sec width
            var markIx = 0;
            var labelMarkIx = 0;
            var st = this.viewStartPosition.TotalSeconds;
            var et = this.viewEndPosition.TotalSeconds;
            var minWidth = markerOffset;
            var modifier = 1;

            while (markerOffset < 10)
            {
                markerOffset += markerOffset;
                modifier += modifier;
            }

            if (this.showFragmentBoundaries && this.Asset != null && this.Asset.IsAdaptiveAsset)
            {
                var currentSegment = this.MediaPlugin.CurrentSegment;
                if (currentSegment != null)
                {
                    var firstVideoStream = currentSegment.SelectedStreams.Where(s => s.Type == StreamType.Video).FirstOrDefault();

                    if (firstVideoStream != null)
                    {
                        st += firstVideoStream.GetStartOffset().TotalSeconds;
                        et += firstVideoStream.GetStartOffset().TotalSeconds;

                        var chunkMarksToRender = firstVideoStream.DataChunks.Where(c => c.Timestamp.TotalSeconds > st && c.Timestamp.TotalSeconds < et);
                        var cnt = 0;
                        foreach (var chunk in chunkMarksToRender)
                        {
                            var t = chunk.Timestamp.TotalSeconds - firstVideoStream.GetStartOffset().TotalSeconds;
                            Line mark;
                            var x = this.TimeCodeToPixel(TimeCode.FromSeconds(t, this.duration.FrameRate)); // t * minWidth;

                            if (markIx >= this.mainBarMarkers.Count)
                            {
                                // create
                                mark = CreateMark(x, layersTop, layersTop, this.mainMarkerStroke);
                                this.TimeMarksCanvas.Children.Add(mark);
                                this.mainBarMarkers.Add(mark);
                            }
                            else
                            {
                                // update
                                mark = this.mainBarMarkers[markIx];
                                mark.Visibility = Visibility.Visible;
                                mark.X1 = x;
                                mark.X2 = x;
                            }

                            Line topMark;
                            if (markIx >= this.topBarMarkers.Count)
                            {
                                // create
                                topMark = CreateMark(x, 1, 1, this.topMarkerStroke);
                                this.TimeMarksCanvas.Children.Add(topMark);
                                this.topBarMarkers.Add(topMark);
                            }
                            else
                            {
                                // update
                                topMark = this.topBarMarkers[markIx];
                                topMark.Visibility = Visibility.Visible;
                                topMark.X1 = x;
                                topMark.X2 = x;
                            }

                            markIx++;

                            if (++cnt % (10 * modifier) != 0)
                            {
                                topMark.StrokeThickness = 1;
                                topMark.Y1 = layersTop - 8;
                                topMark.Y2 = layersTop - 8 + 6;
                            }
                            else
                            {
                                topMark.StrokeThickness = 2;
                                topMark.Y1 = 3;
                                topMark.Y2 = layersTop - 2;

                                // LABEL
                                TextBlock label;
                                if (labelMarkIx >= this.topBarLabels.Count)
                                {
                                    label = new TextBlock
                                    {
                                        FontFamily = new FontFamily("Verdana"),
                                        FontSize = 9,
                                        Foreground = this.topTimeMarkForeground
                                    };

                                    this.TimeMarksCanvas.Children.Add(label);
                                    this.topBarLabels.Add(label);
                                }
                                else
                                {
                                    label = this.topBarLabels[labelMarkIx];
                                    label.Visibility = Visibility.Visible;
                                }

                                label.Text = GetTimeString(TimeCode.FromAbsoluteTime(t + this.StartOffset.TotalSeconds, this.duration.FrameRate));
                                Canvas.SetLeft(label, x - label.ActualWidth - 3);
                                Canvas.SetTop(label, 10);

                                labelMarkIx++;
                            }
                        }
                    }
                }
            }
            else
            {
                for (var t = 0; t < totalTime; t += modifier)
                {
                    if (t < st || t > et)
                    {
                        continue;
                    }

                    Line mark;
                    var x = this.TimeCodeToPixel(TimeCode.FromSeconds((double)t, this.duration.FrameRate)); // t * minWidth;
                    if (markIx >= this.mainBarMarkers.Count)
                    {
                        // create
                        mark = CreateMark(x, layersTop, layersTop, this.mainMarkerStroke);
                        this.TimeMarksCanvas.Children.Add(mark);
                        this.mainBarMarkers.Add(mark);
                    }
                    else
                    {
                        // update
                        mark = this.mainBarMarkers[markIx];
                        mark.Visibility = Visibility.Visible;
                        mark.X1 = x;
                        mark.X2 = x;
                    }

                    Line topMark;
                    if (markIx >= this.topBarMarkers.Count)
                    {
                        // create
                        topMark = CreateMark(x, 1, 1, this.topMarkerStroke);
                        this.TimeMarksCanvas.Children.Add(topMark);
                        this.topBarMarkers.Add(topMark);
                    }
                    else
                    {
                        // update
                        topMark = this.topBarMarkers[markIx];
                        topMark.Visibility = Visibility.Visible;
                        topMark.X1 = x;
                        topMark.X2 = x;
                    }

                    markIx++;

                    if (t % (10 * modifier) != 0)
                    {
                        topMark.StrokeThickness = 1;
                        topMark.Y1 = layersTop - 8;
                        topMark.Y2 = layersTop - 8 + 6;
                    }
                    else
                    {
                        topMark.StrokeThickness = 2;
                        topMark.Y1 = 3;
                        topMark.Y2 = layersTop - 2;

                        // LABEL
                        TextBlock label;
                        if (labelMarkIx >= this.topBarLabels.Count)
                        {
                            label = new TextBlock
                            {
                                FontFamily = new FontFamily("Verdana"),
                                FontSize = 9,
                                Foreground = this.topTimeMarkForeground
                            };

                            this.TimeMarksCanvas.Children.Add(label);
                            this.topBarLabels.Add(label);
                        }
                        else
                        {
                            label = this.topBarLabels[labelMarkIx];
                            label.Visibility = Visibility.Visible;
                        }

                        label.Text = GetTimeString(TimeCode.FromAbsoluteTime(t + this.StartOffset.TotalSeconds, this.duration.FrameRate));
                        Canvas.SetLeft(label, x - label.ActualWidth - 3);
                        Canvas.SetTop(label, 10);

                        labelMarkIx++;
                    }
                }
            }

            // hide any remaining marks
            for (var i = markIx; i < this.mainBarMarkers.Count; i++)
            {
                this.mainBarMarkers[i].Visibility = Visibility.Collapsed;
                this.topBarMarkers[i].Visibility = Visibility.Collapsed;
            }

            for (var i = labelMarkIx; i < this.topBarLabels.Count; i++)
            {
                this.topBarLabels[i].Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Updates the StartPosition, the CurrentRange and the EndPosition text.
        /// </summary>
        private void UpdateTime()
        {
            // time
            this.StartPositionText.Text = GetTimeString(this.viewStartPosition + this.StartOffset);

            double totalSeconds = this.viewEndPosition.TotalSeconds - this.viewStartPosition.TotalSeconds;

            if (totalSeconds < 0)
            {
                this.CurrentRangeText.Text =
                    GetTimeString(this.viewEndPosition + this.StartOffset - this.viewStartPosition);
            }
            else
            {
                this.CurrentRangeText.Text = GetTimeString(this.viewEndPosition - this.viewStartPosition);
            }

            //TimeCode end = TimeCode.FromSeconds(this.viewEndPosition.TotalSeconds + this.StartOffset.TotalSeconds, this.duration.FrameRate);
            //this.EndPositionText.Text = GetTimeString(end);
            this.EndPositionText.Text = GetTimeString(this.viewEndPosition + this.StartOffset);
        }

        /// <summary>
        /// Converts a timecode into a pixel representation.
        /// </summary>
        /// <param name="timecode">The timecode being converted.</param>
        /// <returns>The pixel representation of the timecode.</returns>
        private double TimeCodeToPixel(TimeCode timecode)
        {
            double width = this.VideoLayerCanvas.Width;
            if (double.IsNaN(width))
            {
                width = this.VideoLayerCanvas.ActualWidth;
            }

            double result = (width * (double)timecode.TotalSecondsPrecision) / (double)this.duration.TotalSecondsPrecision;

            if (double.IsNaN(result))
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Valides the view positions to prevent inconsistencies.
        /// </summary>
        private void ValidateViewPositions()
        {
            if (this.viewEndPosition > this.duration)
            {
                this.viewEndPosition = this.duration;
            }

            if (this.viewStartPosition == this.viewEndPosition)
            {
                this.viewEndPosition = this.duration;
            }

            if (this.viewStartPosition > this.duration)
            {
                this.viewStartPosition = TimeCode.FromAbsoluteTime(0, this.duration.FrameRate);
            }
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the ZoomSliderLeftHandler. Attaches to root visual events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ZoomSliderLeftHandler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.activeZoomHandler = ZoomSliderHandler.Left;
            this.lastKnownMousePosition = e.GetPosition(this.ZoomSliderCanvas).X;
            this.AttachToRootMouseEvents();
            this.SubClipPlayheadContentControl.Focus();
            e.Handled = true;
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the ZoomMiddleLeftHandler. Attaches to root visual events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ZoomSliderMiddleHandler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.activeZoomHandler = ZoomSliderHandler.Middle;
            this.lastKnownMousePosition = e.GetPosition(this.ZoomSliderCanvas).X;
            this.AttachToRootMouseEvents();
            this.SubClipPlayheadContentControl.Focus();
            e.Handled = true;
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the ZoomSliderRightHandler. Attaches to the root visual mouse events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ZoomSliderRightHandler_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.activeZoomHandler = ZoomSliderHandler.Right;
            this.lastKnownMousePosition = e.GetPosition(this.ZoomSliderCanvas).X;
            this.AttachToRootMouseEvents();
            this.SubClipPlayheadContentControl.Focus();
            e.Handled = true;
        }

        /// <summary>
        /// Handles the MouseMove event of the ZoomSliderHandler. Refreshes the zoom slider.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ZoomSliderHandler_MouseMove(object sender, MouseEventArgs e)
        {
            double offset = this.lastKnownMousePosition - e.GetPosition(this.ZoomSliderCanvas).X;

            if (this.RefreshZoomSlider(this.activeZoomHandler, offset))
            {
                this.lastKnownMousePosition = e.GetPosition(this.ZoomSliderCanvas).X;
            }
        }

        /// <summary>
        /// Set ZoomSlider's position corresponding to the offset.
        /// </summary>
        /// <param name="zoomHandler">ZoomSliderHandler value.<see cref="ZoomSliderHandler"/>.</param>
        /// <param name="offset">Mouse move offset.</param>
        /// <returns>True if the same slider can move in the same direction else false.</returns>
        private bool RefreshZoomSlider(ZoomSliderHandler zoomHandler, double offset)
        {
            double newX;
            bool setMousePosition = false;

            switch (zoomHandler)
            {
                case ZoomSliderHandler.Left:
                    newX = Canvas.GetLeft(this.ZoomSliderLeftHandler) - offset;
                    if (newX < 0)
                    {
                        newX = 0;
                    }
                    else if (newX >
                             Canvas.GetLeft(this.ZoomSliderRightHandler) - MinimumZoomSliderSize -
                             this.ZoomSliderLeftHandler.ActualWidth)
                    {
                        newX = Canvas.GetLeft(this.ZoomSliderRightHandler) - MinimumZoomSliderSize -
                               this.ZoomSliderLeftHandler.ActualWidth;
                    }
                    else
                    {
                        setMousePosition = true;
                    }

                    // Check if there is any change.
                    if ((double)this.ZoomSliderLeftHandler.GetValue(Canvas.LeftProperty) != newX)
                    {
                        Canvas.SetLeft(this.ZoomSliderLeftHandler, newX);
                        this.RefreshZoomSliderMiddleHandler();
                    }

                    break;
                case ZoomSliderHandler.Right:
                    newX = Canvas.GetLeft(this.ZoomSliderRightHandler) - offset;
                    if (newX > this.TimelineGrid.ActualWidth - this.ZoomSliderRightHandler.ActualWidth)
                    {
                        newX = this.TimelineGrid.ActualWidth - this.ZoomSliderRightHandler.ActualWidth;
                    }
                    else if (newX <
                             Canvas.GetLeft(this.ZoomSliderLeftHandler) + this.ZoomSliderLeftHandler.ActualWidth +
                             MinimumZoomSliderSize)
                    {
                        newX = Canvas.GetLeft(this.ZoomSliderLeftHandler) + this.ZoomSliderLeftHandler.ActualWidth +
                               MinimumZoomSliderSize;
                    }
                    else
                    {
                        setMousePosition = true;
                    }

                    // Check if there is any change.
                    if ((double)this.ZoomSliderRightHandler.GetValue(Canvas.LeftProperty) != newX)
                    {
                        Canvas.SetLeft(this.ZoomSliderRightHandler, newX);
                        this.RefreshZoomSliderMiddleHandler();
                    }

                    break;
                case ZoomSliderHandler.Middle:
                    newX = Canvas.GetLeft(this.ZoomSliderMiddleHandler) - offset;

                    if (newX - this.ZoomSliderLeftHandler.ActualWidth < 0)
                    {
                        newX = this.ZoomSliderLeftHandler.ActualWidth;
                    }
                    else if (newX + this.ZoomSliderMiddleHandler.ActualWidth + this.ZoomSliderRightHandler.ActualWidth >
                             this.TimelineGrid.ActualWidth)
                    {
                        newX = this.TimelineGrid.ActualWidth -
                               (this.ZoomSliderMiddleHandler.ActualWidth + this.ZoomSliderRightHandler.ActualWidth);
                    }
                    else
                    {
                        setMousePosition = true;
                    }

                    if ((double)this.ZoomSliderLeftHandler.GetValue(Canvas.LeftProperty) != newX - this.ZoomSliderLeftHandler.ActualWidth)
                    {
                        Canvas.SetLeft(this.ZoomSliderLeftHandler, newX - this.ZoomSliderLeftHandler.ActualWidth);
                    }

                    if ((double)this.ZoomSliderRightHandler.GetValue(Canvas.LeftProperty) != newX + this.ZoomSliderMiddleHandler.ActualWidth)
                    {
                        Canvas.SetLeft(this.ZoomSliderRightHandler, newX + this.ZoomSliderMiddleHandler.ActualWidth);
                    }

                    if ((double)this.ZoomSliderMiddleHandler.GetValue(Canvas.LeftProperty) != newX)
                    {
                        Canvas.SetLeft(this.ZoomSliderMiddleHandler, newX);
                    }

                    break;
            }

            var zoomSliderLeftPosition = Canvas.GetLeft(this.ZoomSliderLeftHandler);
            var zoomSliderRightPosition = Canvas.GetLeft(this.ZoomSliderRightHandler) + this.ZoomSliderRightHandler.Width;

            double viewStartPositionInSeconds = this.viewStartPosition.TotalSeconds;
            double viewEndPositionInSeconds = this.viewEndPosition.TotalSeconds;

            if (this.zoomDurationSlope != 0)
            {
                var currentZoomSize = zoomSliderRightPosition - zoomSliderLeftPosition;
                var expectedZoomDurationInSeconds = (this.zoomDurationSlope * currentZoomSize) + this.zoomDurationInterceptInSeconds;
                double currentZoomDurationInSeconds = 0;
                double correction = 0;

                if (zoomSliderLeftPosition == 0)
                {
                    viewStartPositionInSeconds = 0;
                    viewEndPositionInSeconds = expectedZoomDurationInSeconds;
                }
                else if (zoomSliderRightPosition == this.TimelineGrid.Width)
                {
                    viewEndPositionInSeconds = this.duration.TotalSeconds;
                    viewStartPositionInSeconds = viewEndPositionInSeconds - expectedZoomDurationInSeconds;
                }
                else switch (zoomHandler)
                    {
                        case ZoomSliderHandler.Left:
                            viewStartPositionInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * zoomSliderLeftPosition;

                            currentZoomDurationInSeconds = viewEndPositionInSeconds - viewStartPositionInSeconds;
                            correction = expectedZoomDurationInSeconds - currentZoomDurationInSeconds;

                            viewStartPositionInSeconds -= correction;
                            break;
                        case ZoomSliderHandler.Right:
                            viewEndPositionInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * zoomSliderRightPosition;

                            currentZoomDurationInSeconds = viewEndPositionInSeconds - viewStartPositionInSeconds;
                            correction = expectedZoomDurationInSeconds - currentZoomDurationInSeconds;

                            viewEndPositionInSeconds += correction;
                            break;
                        case ZoomSliderHandler.Middle:
                            viewStartPositionInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * zoomSliderLeftPosition;
                            viewEndPositionInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * zoomSliderRightPosition;

                            currentZoomDurationInSeconds = viewEndPositionInSeconds - viewStartPositionInSeconds;
                            correction = (expectedZoomDurationInSeconds - currentZoomDurationInSeconds) / 2;

                            viewStartPositionInSeconds -= correction;
                            viewEndPositionInSeconds += correction;
                            break;
                    }
            }
            else
            {
                viewStartPositionInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * zoomSliderLeftPosition;
                viewEndPositionInSeconds = (this.duration.TotalSeconds / this.TimelineGrid.Width) * zoomSliderRightPosition;
            }

            if (viewStartPositionInSeconds < 0)
            {
                viewStartPositionInSeconds = 0;
            }

            if (viewEndPositionInSeconds > this.duration.TotalSeconds)
            {
                viewEndPositionInSeconds = this.duration.TotalSeconds;
            }

            this.viewStartPosition = TimeCode.FromAbsoluteTime(viewStartPositionInSeconds, this.duration.FrameRate);
            this.viewEndPosition = TimeCode.FromAbsoluteTime(viewEndPositionInSeconds, this.duration.FrameRate);

            this.SetAvailableTime(this.availableTime);
            this.RefreshLayersMargin();
            this.RefreshTimeMarks();
            this.RefreshElements();
            this.RefreshSubClipMarks();
            this.DownloadProgressBar.Refresh(this.TimelineGrid.ActualWidth / (this.ViewEndPosition.TotalSeconds - this.ViewStartPosition.TotalSeconds) * this.duration.TotalSeconds);
            this.UpdateTime();

            TimeCode playHeadPosition = this.GetPositionWithoutStartOffset(this.currentPosition);
            this.SetPlayHeadPosition(playHeadPosition);

            return setMousePosition;
        }

        /// <summary>
        /// Handles the MouseLeftButtonUp event of the Zoom Slider Handler. Refreshes the elemnts previews and detaches of the root visual mouse events.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ZoomSliderHandler_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.activeZoomHandler = ZoomSliderHandler.None;
            this.DetachZoomSliderToRootMouseEvents();
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args instance containing the event data.</param>
        private void RootVisual_KeyDown(object sender, KeyEventArgs e)
        {
            bool handleKey = this.CanHandleKeyStroke(e.OriginalSource);

            if (handleKey)
            {
                switch (e.Key)
                {
                    case Key.Add:
                        this.ZoomHandler(Zoom.In);
                        e.Handled = true;
                        break;

                    case Key.Subtract:
                        this.ZoomHandler(Zoom.Out);
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Attachs to the root visual mouse events.
        /// </summary>
        private void AttachToRootMouseEvents()
        {
            Application.Current.RootVisual.MouseLeftButtonUp += this.ZoomSliderHandler_MouseLeftButtonUp;
            Application.Current.RootVisual.MouseMove += this.ZoomSliderHandler_MouseMove;
        }

        /// <summary>
        /// Detach fom the root visual mouse events.
        /// </summary>
        private void DetachZoomSliderToRootMouseEvents()
        {
            Application.Current.RootVisual.MouseLeftButtonUp -= this.ZoomSliderHandler_MouseLeftButtonUp;
            Application.Current.RootVisual.MouseMove -= this.ZoomSliderHandler_MouseMove;
        }

        /// <summary>
        /// Handle the keyboard Zoom In/Out command.
        /// It tries to put the playhead at the center of the visible portion of the slider canvas 
        /// and then decides on if the ZoomSliderRightHandler should move or ZoomSliderLeftHandler should move.
        /// </summary>
        /// <param name="zoom">The <see cref="Zoom"/>value.</param>
        /// <param name="zoomValue">The zoom value.</param>
        private void ZoomHandler(Zoom zoom, double zoomValue)
        {
            ZoomSliderHandler zoomSliderHandler = this.GetPositionWithoutStartOffset(this.currentPosition).TotalSeconds >= this.ViewStartPosition.TotalSeconds + ((this.viewEndPosition - this.viewStartPosition).TotalSeconds / 2)
                                                      ? zoom == Zoom.In ? ZoomSliderHandler.Left : ZoomSliderHandler.Right
                                                      : zoom == Zoom.In ? ZoomSliderHandler.Right : ZoomSliderHandler.Left;

            double offset = zoomSliderHandler == ZoomSliderHandler.Left
                                ? zoom == Zoom.In ? 0 - zoomValue : zoomValue
                                : zoom == Zoom.In ? zoomValue : 0 - zoomValue;

            // if RefreshZoomSlider returns false then this means that the slider didn't moved by the given amount
            // so move the other slider by the same amount.
            if (!this.RefreshZoomSlider(zoomSliderHandler, offset))
            {
                zoomSliderHandler = zoomSliderHandler == ZoomSliderHandler.Left ? ZoomSliderHandler.Right : ZoomSliderHandler.Left;
                offset = zoomSliderHandler == ZoomSliderHandler.Left
                             ? zoom == Zoom.In ? 0 - zoomValue : zoomValue
                             : zoom == Zoom.In ? zoomValue : 0 - zoomValue;
                this.RefreshZoomSlider(zoomSliderHandler, offset);
            }
        }

        /// <summary>
        /// Handle the keyboard Zoom In/Out command and mouse wheel operation.
        /// It tries to put the playhead at the center of the visible portion of the slider canvas 
        /// and then decides on if the ZoomSliderRightHandler should move or ZoomSliderLeftHandler should move.
        /// </summary>
        /// <param name="zoom">The <see cref="Zoom"/>value.</param>
        private void ZoomHandler(Zoom zoom)
        {
            this.ZoomHandler(zoom, ZoomValue);
        }

        /// <summary>
        /// Raises the PositionChange event.
        /// </summary>
        /// <param name="timeCode">The timecode.</param>
        private void OnPositionChange(TimeCode timeCode)
        {
            EventHandler<PositionChangeEventArgs> change = this.PositionChange;
            if (change != null)
            {
                change(this, new PositionChangeEventArgs { NewPosition = timeCode });
            }
        }

        /// <summary>
        /// Raises the MovingPlayhead event.
        /// </summary>
        private void OnMovingPlayhead()
        {
            EventHandler movingPlayheadHandler = this.MovingPlayHead;
            if (movingPlayheadHandler != null)
            {
                movingPlayheadHandler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Handles the SizeChanged event of the user control.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args instance containing the event data.</param>
        private void TimelineControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.RefreshZoomSlider();
            this.RefreshTimeMarks();
            this.RefreshElements();
            this.RefreshSubClipMarks();

            TimeCode playHeadPosition = this.GetPositionWithoutStartOffset(this.currentPosition);

            this.SetPlayHeadPosition(playHeadPosition);

            this.SetAvailableTime(this.availableTime);

            this.TimelineGrid.Clip = new RectangleGeometry
                    {
                        Rect = new Rect(0, 0, this.TimelineGrid.ActualWidth, this.TimelineGrid.ActualHeight)
                    };

            this.OnResized();
            this.DownloadProgressBar.Refresh(this.TimelineGrid.ActualWidth / (this.ViewEndPosition.TotalSeconds - this.ViewStartPosition.TotalSeconds) * this.duration.TotalSeconds);
        }

        /// <summary>
        /// Handles the Resized event of the user control.
        /// </summary>
        private void OnResized()
        {
            EventHandler resized = this.Resized;
            if (resized != null)
            {
                resized(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Removes the existing sub clip mark of the given <see cref="ScrubShiftType"/>.
        /// </summary>
        /// <param name="scrubShiftType">The type of the subclip mark to remove.</param>
        private void RemoveSubClipMark(ScrubShiftType scrubShiftType)
        {
            if (this.subClipMarks.ContainsKey(scrubShiftType))
            {
                Rectangle rectangle = this.subClipMarks[scrubShiftType];

                if (this.MarkInOutLayerCanvas.Children.Contains(rectangle))
                {
                    this.MarkInOutLayerCanvas.Children.Remove(rectangle);
                    this.subClipMarks.Remove(scrubShiftType);
                }
            }
        }

        /// <summary>
        /// Adds a subclip mark of the given <see cref="ScrubShiftType"/> at the given <paramref name="position"/>.
        /// </summary>
        /// <param name="scrubShiftType">The tipe ob the subclip mark to add.</param>
        /// <param name="position">The position where the subclip mark will be added.</param>
        /// <param name="color">The color of the subclip mark.</param>
        private void AddSubClipMark(ScrubShiftType scrubShiftType, TimeCode position, Color color)
        {
            RotateTransform rotateTransform = new RotateTransform { Angle = 45 };
            Rectangle rectangle = new Rectangle
                                      {
                                          Width = 6,
                                          Height = 6,
                                          RenderTransform = rotateTransform,
                                          Fill = new SolidColorBrush(color),
                                          Tag = position
                                      };

            ToolTipService.SetToolTip(rectangle, position.ToString());

            this.MarkInOutLayerCanvas.Children.Add(rectangle);

            TimeCode timeCode = this.GetPositionWithoutStartOffset(position);

            double x = this.TimeCodeToPixel(timeCode);

            if (!double.IsNaN(x))
            {
                Canvas.SetLeft(rectangle, x);
            }

            Canvas.SetTop(rectangle, 0d);
            Canvas.SetZIndex(rectangle, 1000);

            this.subClipMarks.Add(scrubShiftType, rectangle);
        }

        /// <summary>
        /// Removes mark out if it is before the new mark in position.
        /// </summary>
        /// <param name="markIn">The new mark in position.</param>
        private void DepurateMarkOut(TimeCode markIn)
        {
            if (this.subClipMarks.ContainsKey(ScrubShiftType.Out))
            {
                TimeCode markOut = (TimeCode)this.subClipMarks[ScrubShiftType.Out].Tag;

                if (markIn > markOut)
                {
                    this.RemoveMarkOut();
                }
            }
        }

        /// <summary>
        /// Removes mark in if it is after the new mark out position.
        /// </summary>
        /// <param name="markOut">The new mark out position.</param>
        private void DepurateMarkIn(TimeCode markOut)
        {
            if (this.subClipMarks.ContainsKey(ScrubShiftType.In))
            {
                TimeCode markIn = (TimeCode)this.subClipMarks[ScrubShiftType.In].Tag;

                if (markIn > markOut)
                {
                    this.RemoveMarkIn();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ToolTip.IsOpen = true;
        }

        private void RefreshElements()
        {
            this.RefreshLayersMargin();
            this.eventAggregator.GetEvent<RefreshElementsEvent>().Publish(new RefreshElementsEventArgs(this.VideoLayerCanvas.Width, CommentMode.SubClip));
        }
    }
}
