// <copyright file="IPlayByPlayBoxesPresentationModel.cs" company="Microsoft Corporation">
// ===============================================================================
//
//
// Project: Microsoft Silverlight Rough Cut Editor
// FILES: IPlayByPlayBoxesPresentationModel.cs                     
//
// ===============================================================================
// Copyright 2010 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// ===============================================================================
// </copyright>

namespace RCE.Modules.PlayByPlay.Views.TimelineBar
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using Microsoft.Practices.Composite.Presentation.Commands;

    using RCE.Infrastructure.Models;

    public interface IPlayByPlayBoxesPresentationModel : ITimelineBarElementModel, INotifyPropertyChanged
    {
        IPlayByPlayDisplayBox DisplayView { get; }

        IList<string> TemplateTypes { get; }

        DelegateCommand<object> CloseCommand { get; }

        DelegateCommand<object> SaveCommand { get; }

        DelegateCommand<object> DeleteCommand { get; }

        double Time { get; set; }

        string SelectedTemplateType { get; set; }

        void ShowDisplayBox();

        void RaisePreviewClickedEvent();

        void CloseDisplayView();

        void ShowEditBox();
    }
}