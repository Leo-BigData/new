# Owin SignalR WebApi Self Hosted
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Entity Framework
- ASP.NET Web API
- automapper
- SignalR
- OWIN
- OWIN self-hosting
## Topics
- Dependancy Injection
- SignalR
- Real-time web
- OWIN
- OWIN Self-Host
## Updated
- 03/04/2016
## Description

<table style="border:1px solid #cccccc; padding:10px; background-color:#eeeeee">
<thead>
<tr>
<th style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
Table of contents</th>
</tr>
</thead>
<tbody>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#Introduction">Introduction</a></td>
</tr>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#ProjectOutline">Project Outline</a></td>
</tr>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#SettingUpTheProject">Setting up the project</a></td>
</tr>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#OwinSignalR_Data">OwinSignalR.Data</a></td>
</tr>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#OwinSignalR_Pulse">OwinSignalR.Pulse</a></td>
</tr>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#OwinSignalR_Client">OwinSignalR.Client</a></td>
</tr>
<tr>
<td style="text-align:left; border-bottom-width:1px; border-bottom-style:dotted; border-bottom-color:#cccccc">
<a href="#OwinSignalR_Notificator">OwinSignalR.Notificator</a></td>
</tr>
</tbody>
</table>
<h2><a name="Introduction"></a>Introduction</h2>
<p>What is the <strong>Problem</strong>? &ndash; You are responsible for multiple applications that need to show real time notifications, show real time graphs that update as the data becomes available, update dashboards as live events happen via the backend
 processes. You also need to keep track of all the connected clients (users) and authenticate the connections.<br>
<br>
The solution you came up with (if you are already using SignalR)? &ndash; Implement SignalR in all of your applications (Hubs that your JavaScript client connects to and waits for a callback/notification). You have multiple code bases that implement the same
 functionality; that is notifying connected clients (users) that a specific event took place, and passing on the data for that event.<br>
<br>
The solution that I propose? &ndash; Implement<strong> one standalone/isolated</strong> SignalR project/solution that manages all your clients (users) connections, knows who is connected at all time, receives notifications from your backend process and forwards
 on the event(s) to the intended connected client(s) (user(s)). This standalone/isolated project/solution will also authenticate all your connected clients via unique API tokens and authorized referral URLS (allowed domains).<br>
<br>
Here is a graph of how the Website/Web Application connects and receives data.</p>
<h2><a name="ProjectOutline"></a>Project Outline</h2>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6574.Graph.png"><img src="http://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/6574.Graph.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
The solution consists of the following projects:<br>
<br>
</p>
<ol>
<li>OwinSignalR.Data </li><li>OwinSignalR.Pulse </li><li>OwinSignalR.Common </li><li>OwinSignalR.PulseHost </li><li>OwinSignalR.Notificator </li><li>OwinSignalR.Client </li></ol>
<div>
<ol>
<li><strong>OwinSignalR.Data</strong>
<p style="font-size:11px">This project contains the data layer and database access code</p>
</li><li><strong>OwinSignalR.Pulse</strong><br>
<p style="font-size:11px">This project receives the SignalR connections, and also receives the data that is sent from any backend process or backend service.</p>
</li><li><strong>OwinSignalR.Common</strong><br>
<p style="font-size:11px">This project contains common code used by the other projects. It also contains the code used to connect to the OwinSignalR.Pulse project from any backend process or backend service.</p>
</li><li><strong>OwinSignalR.PulseHost</strong><br>
<p style="font-size:11px">This is a console application that hosts the OwinSignalR.Pulse project.</p>
</li><li><strong>OwinSignalR.Notificator</strong><br>
<p style="font-size:11px">This project acts as a backend service/process that is consintly sending data to the Website/WebApplication</p>
</li><li><strong>OwinSignalR.Client</strong><br>
<p style="font-size:11px">This is a demo Website/Webapplication that connects to OwinSignalR.Pulse and receives constant data updates from OwinSignalR.Notificator.</p>
</li></ol>
<h2><a name="SettingUpTheProject"></a>Setting up the project:</h2>
<ol>
<li>Step1: Download and build the application to resolve the packages </li><li>Step2: Run the CreateDatabase.sql script found in the root on your SQL server instance. This will create the database structure and will also insert a test application with the relevant information
</li><li>Step3: Right click on the solution and select &ldquo;Multiple startup projects&rdquo;, it should look similar to this:<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/0624.startup--projects.png"><img src="http://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/0624.startup--projects.png" alt="" style="border-width:0px; border-style:solid"></a>
</li><li>Step4: Expand the OwinSignalR.Client project and set Demo1.html as the startup page
</li><li>Step5: Run the solution </li></ol>
<div>2 console applications should start up and 1 website. After the projects start you should see the following (the line below &ldquo;OwinSignalR&hellip;&rdquo; is a unique id for the SignalR connection. Yours will probably be different)<br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6735.PulseHost-Console.png"><img src="http://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/6735.PulseHost-Console.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/3362.Notificator-Console.png"><img src="http://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/3362.Notificator-Console.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/3681.Demo-Html.png"><img src="http://social.technet.microsoft.com/wiki/resized-image.ashx/__size/550x0/__key/communityserver-wikis-components-files/00-00-00-00-05/3681.Demo-Html.png" alt="" style="border-width:0px; border-style:solid"></a><br>
<br>
<p>If you don&rsquo;t see a connection Id in the OwinSignalR.PulseHost console window, please refresh the demo.html page (f5 or ctr&#43;f5)</p>
<p>When you see the unique Id in the first console window the demo.html page connected successfully with the OwinSignalR.PulseHost. You can now hit the enter key in the OwinSignalR.Notificator console window to start sending the notifications to the demo.html
 page. The gauges should start moving and the&rdquo;Activity feed&rdquo; should start receiving notifications of events as they happen.<br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/7875.Gauge.gif" style="font-size:12.1px"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/7875.Gauge.gif" alt="" style="border-width:0px; border-style:solid; width:200px"></a><br>
<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/4530.Activity-Feed.gif" style="font-size:12.1px"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/4530.Activity-Feed.gif" alt="" style="border-width:0px; border-style:solid; width:200px"></a></p>
</div>
</div>
<p>Let??????s discuss the projects:</p>
<h4><a name="OwinSignalR_Data"></a>OwinSignalR.Data</h4>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1300.OwinSignalR.Data.png"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/1300.OwinSignalR.Data.png" alt="" style="border-width:0px; border-style:solid; width:255px"></a></p>
<ul>
<li>OwinSignalR.Data /Configuration/AutomapperConfiguration.cs
<p style="font-size:11px">This file contains the mapping code to map EntityFrOwinSignalR.Pulseamework Models to DTO&rsquo;s</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:scroll; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
class</code> <code style="color:#000000">AutomapperConfiguration</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Configure() </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Mapper.CreateMap&lt;Application, ApplicationDto&gt;()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApplicationId&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 , opt =&gt; opt.MapFrom(src =&gt; src.ApplicationId))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApplicationName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 , opt =&gt; opt.MapFrom(src =&gt; src.ApplicationName))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApiToken&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 , opt =&gt; opt.MapFrom(src =&gt; src.ApiToken))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApplicationSecret&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; , opt =&gt;
 opt.MapFrom(src =&gt; src.ApplicationSecret))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApplicationReferralUrls, opt =&gt; opt.MapFrom(src =&gt;
 src.ApplicationReferralUrls));</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Mapper.CreateMap&lt;ApplicationReferralUrl, ApplicationReferralUrlDto&gt;()</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApplicationReferralUrlId, opt =&gt; opt.MapFrom(src =&gt;
 src.ApplicationReferralUrlId))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.ApplicationId&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 , opt =&gt; opt.MapFrom(src =&gt; src.ApplicationId))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.ForMember(dest =&gt; dest.Url&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 , opt =&gt; opt.MapFrom(src =&gt; src.Url));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Data/DataAccessors/ApplicationDataAccessor.cs
<p style="font-size:11px">This file contains the data access code that fetches the data from the database.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">interface</code> <code style="color:#000000">
IApplicationDataAccessor </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">Application FetchApplication(</code><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">apiToken);</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ApplicationDataAccessor</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">: DataAccessorBase, IApplicationDataAccessor</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">Application FetchApplication(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">apiToken)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var query = (from a
</code><code style="color:#006699; font-weight:bold">in</code> <code style="color:#000000">
OwinSignalrDbContext.Applications</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">where a.ApiToken
 == apiToken</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">select a).Include(</code><code style="color:blue">&quot;ApplicationReferralUrls&quot;</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">query.FirstOrDefault();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Data/DataAccessors/DataAccessorBase.cs
<p style="font-size:11px">This is the base class from where all DataAccessors enherit from to access the DbContext</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
DataAccessorBase</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">protected</code>
<code style="color:#000000">IDataContext DataContext </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">get</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">ObjectFactory.GetInstance&lt;IDataContext&gt;();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">protected</code>
<code style="color:#000000">IOwinSignalrDbContext OwinSignalrDbContext </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">get</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">DataContext.OwinSignalrDbContext;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Data/Models/IDataContext.cs
<p style="font-size:11px">This file contains the IDataContext interface and the implementation for it. This interface is used when we need to access the
<span style="font-family:Consolas; color:#5591af">IOwinSignalrDbContext</span> interface.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">interface</code> <code style="color:#000000">
IDataContext</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">IOwinSignalrDbContext OwinSignalrDbContext {
</code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">void</code>
<code style="color:#000000">Initialize(IOwinSignalrDbContext owinSignalrDbContext);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
DataContext </code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">: IDataContext</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Private Members</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#000000">IOwinSignalrDbContext _owinSignalrDbContext;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IOwinSignalrDbContext OwinSignalrDbContext</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">get</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">_owinSignalrDbContext;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Initialize(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">IOwinSignalrDbContext owinSignalrDbContext)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_owinSignalrDbContext = owinSignalrDbContext;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Data/Models/IOwinSignalrDbContext.cs
<p style="font-size:11px">This file contains the <span style="font-family:Consolas; color:#5591af">
IOwinSignalrDbContext</span> interface and the implementation for it. This interface is used when we need to access the EntityFramework DbContext</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">interface</code> <code style="color:#000000">
IOwinSignalrDbContext </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">DbSet&lt;Application&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Applications&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">DbSet&lt;ApplicationReferralUrl&gt; ApplicationReferralUrls {
</code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">partial</code> <code style="color:#006699; font-weight:bold">
class</code> <code style="color:#000000">OwinSignalrDbContext</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">: IOwinSignalrDbContext</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Data/Models/OwinSignalrDbContext.edmx
<p style="font-size:11px">This file is the EntityFramework edmx that is generated from the database. You might have noticed that the
<span style="font-family:Consolas; color:#5591af">OwinSignalrDbContext</span> is marked as
<span style="font-family:Consolas; color:#5591af">partial</span>, the EntityFramework edmx contains the other partial class that actually implements the rest of
<span style="font-family:Consolas; color:#5591af">IOwinSignalrDbContext<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8105.Edmx-Layout.png"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8105.Edmx-Layout.png" alt="" style="border-width:0px; border-style:solid; width:444px"></a></span></p>
</li><li>OwinSignalR.Data/Services/ApplicationService.cs
<p style="font-size:11px">This service is used by all referencing projects to fetch Application related information.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">interface</code> <code style="color:#000000">
IApplicationService </code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">ApplicationDto FetchApplication(</code><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">apiToken);</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ApplicationService</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">: IApplicationService</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:4px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IApplicationDataAccessor ApplicationDataAccessor { </code>
<code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:4px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">ApplicationDto FetchApplication(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">apiToken)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:4px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:12px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">Mapper.Map&lt;ApplicationDto&gt;(ApplicationDataAccessor.FetchApplication(apiToken));</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;</code><span style="margin-left:4px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</li></ul>
<h4><a name="OwinSignalR_Pulse"></a>OwinSignalR.Pulse</h4>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8662.OwinSignalR.Pulse.png"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/8662.OwinSignalR.Pulse.png" alt="" style="border-width:0px; border-style:solid; width:288px"></a></p>
<ul>
<li>OwinSignalR.Pulse/Attributes/ApiAuthorizeAttribute.cs
<p style="font-size:11px">This file contains code to check if the API call contains a valid API Token, Application secret or if it is coming from one of the predefined URL's</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:scroll; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ApiAuthorizeAttribute</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">: AuthorizeAttribute</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IApplicationService ApplicationService { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">ApiAuthorizeAttribute() </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">StructureMap.ObjectFactory.BuildUp(</code><code style="color:#006699; font-weight:bold">this</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">protected</code>
<code style="color:#006699; font-weight:bold">override</code> <code style="color:#006699; font-weight:bold">
bool</code> <code style="color:#000000">IsAuthorized(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">HttpActionContext actionContext)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var queryString = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x =&gt; x.Key, x =&gt; x.Value);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">applicationSecret;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(!queryString.TryGetValue(Constants.TOKEN_QUERYSTRING,
</code><code style="color:#006699; font-weight:bold">out</code> <code style="color:#000000">
token))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(!queryString.TryGetValue(Constants.APPLICATION_SECRET,
</code><code style="color:#006699; font-weight:bold">out</code> <code style="color:#000000">
applicationSecret))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(String.IsNullOrEmpty(applicationSecret))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(!IsValidReferer(token, actionContext))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">else</code>
<code style="color:#006699; font-weight:bold">if</code> <code style="color:#000000">
(!IsApplicationSecretValidForToken(token, applicationSecret))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">true</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">bool</code> <code style="color:#000000">
IsApplicationSecretValidForToken(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
applicationSecret)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var application = ApplicationService.FetchApplication(token);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(application == </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">application.ApplicationSecret == applicationSecret;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">bool</code> <code style="color:#000000">
IsValidReferer(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">, HttpActionContext actionContext)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var application = ApplicationService.FetchApplication(token);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(application == </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">IEnumerable&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;
 headerValue;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(!actionContext.Request.Headers.TryGetValues(</code><code style="color:blue">&quot;Referer&quot;</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">out</code> <code style="color:#000000">
headerValue))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">else</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var urlReferral = Helpers.HttpHelper.GetUrlReferer(headerValue.ElementAt(0));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">application.ApplicationReferralUrls.Any(x =&gt; x.Url == urlReferral);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/Attributes/HubAuthorizeAttribute.cs
<p style="font-size:11px">This file contains code to check if the Hub conenction contains a valid API Token and if it is coming from one of the predefined URL's</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
HubAuthorizeAttribute</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">: AuthorizeAttribute</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IApplicationService ApplicationService { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">HubAuthorizeAttribute() </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">StructureMap.ObjectFactory.BuildUp(</code><code style="color:#006699; font-weight:bold">this</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">override</code> <code style="color:#006699; font-weight:bold">
bool</code> <code style="color:#000000">AuthorizeHubConnection(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.AspNet.SignalR.Hubs.HubDescriptor.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.SignalR.Hubs.HubDescriptor">Microsoft.AspNet.SignalR.Hubs.HubDescriptor</a> hubDescriptor</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">, IRequest request)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var authorizeHubConnection =
</code><code style="color:#006699; font-weight:bold">base</code><code style="color:#000000">.AuthorizeHubConnection(hubDescriptor, request);</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var tokenValues&nbsp;&nbsp;&nbsp; = request.QueryString.GetValues(Constants.TOKEN_QUERYSTRING);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var clientIdValues = request.QueryString.GetValues(Constants.UNIQUE_CLIENT_ID);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">((tokenValues.Count() == 0 || tokenValues.Count() &gt; 1) || (clientIdValues.Count() == 0 || clientIdValues.Count() &gt; 1))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var application = ApplicationService.FetchApplication(tokenValues.ElementAt(0));</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(application == </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var urlReferer = GetUrlReferer(request);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">application.ApplicationReferralUrls.Any(x =&gt; x.Url == urlReferer);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">protected</code>
<code style="color:#006699; font-weight:bold">override</code> <code style="color:#006699; font-weight:bold">
bool</code> <code style="color:#000000">UserAuthorized(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000"><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Security.Principal.IPrincipal.aspx" target="_blank" title="Auto generated link to System.Security.Principal.IPrincipal">System.Security.Principal.IPrincipal</a> user)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">true</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
GetUrlReferer(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">IRequest request)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">Helpers.HttpHelper.GetUrlReferer(request.Headers[</code><code style="color:blue">&quot;Referer&quot;</code><code style="color:#000000">]);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/Attributes/DependencyInjectionConfiguration.cs
<p style="font-size:11px">This file contains the setup code for the Dependency Injection used throughout the application</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:scroll; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
class</code> <code style="color:#000000">DependencyInjectionConfiguration</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Configure()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">ObjectFactory.Initialize(x =&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">x.For&lt;Data.Models.IDataContext&gt;().HybridHttpOrThreadLocalScoped().Use&lt;Data.Models.DataContext&gt;();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">x.For&lt;Data.Services.IApplicationService&gt;().Use&lt;Data.Services.ApplicationService&gt;();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">x.For&lt;Data.DataAccessors.IApplicationDataAccessor&gt;().Use&lt;Data.DataAccessors.ApplicationDataAccessor&gt;();</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">x.SetAllProperties(y =&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">y.OfType&lt;Data.Services.IApplicationService&gt;();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">y.OfType&lt;Data.DataAccessors.IApplicationDataAccessor&gt;();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">});</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">});</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/Helpers/HttpHelper.cs
<p style="font-size:11px">This file contains code to easily extract the URL referrer (domain from where the request is coming from)</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:scroll; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
class</code> <code style="color:#000000">HttpHelper</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
string</code> <code style="color:#000000">GetUrlReferer(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">referer)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">.IsNullOrEmpty(referer))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">.Empty;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">referer = referer.IndexOf(</code><code style="color:blue">&quot;://&quot;</code><code style="color:#000000">) &gt; -1
 ? referer.Substring(referer.IndexOf(</code><code style="color:blue">&quot;://&quot;</code><code style="color:#000000">) &#43; 3) : referer;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">referer = referer.IndexOf(</code><code style="color:blue">&quot;/&quot;</code><code style="color:#000000">) &gt; -1 ?
 referer.Substring(0, referer.IndexOf(</code><code style="color:blue">&quot;/&quot;</code><code style="color:#000000">) - 1) : referer;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">referer = referer.IndexOf(</code><code style="color:blue">&quot;:&quot;</code><code style="color:#000000">) &gt; -1 ?
 referer.Split(</code><code style="color:blue">':'</code><code style="color:#000000">)[0] : referer;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">referer;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/ConnectionManager.cs
<p style="font-size:11px">This file contains code to keep track of all the connections made via SignalR</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ConnectionManager</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Private Members</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
ConcurrentDictionary&lt;Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;, ClientConnection&gt; _clients;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Public Properties</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
ClientConnection ActiveConnections(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
clientId)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(_clients == </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ClientConnection();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">else</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">ClientConnection value;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(_clients.TryGetValue(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;(token, clientId),
</code><code style="color:#006699; font-weight:bold">out</code> <code style="color:#000000">
value))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">value;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">else</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ClientConnection();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Static Methods</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Add(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
clientId</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
connectionId)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(_clients == </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">_clients =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ConcurrentDictionary&lt;Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;, ClientConnection&gt;();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var user = _clients.GetOrAdd(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;(token, clientId),
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ClientConnection</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Connections =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
List&lt;ClientConnectionDetials&gt;()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">});</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">lock</code>
<code style="color:#000000">(user.Connections)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">user.Connections.Add(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">ClientConnectionDetials { ConnectionId = connectionId });</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Remove(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
clientId</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
connectionId)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">ClientConnection clientConnection;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_clients.TryGetValue(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;(token, clientId),
</code><code style="color:#006699; font-weight:bold">out</code> <code style="color:#000000">
clientConnection);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(clientConnection != </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">lock</code>
<code style="color:#000000">(clientConnection.Connections)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">clientConnection.Connections.RemoveAll(x =&gt; x.ConnectionId
 == connectionId);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(!clientConnection.Connections.Any())</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">{&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">ClientConnection removedClient;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">_clients.TryRemove(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;(token, clientId),
</code><code style="color:#006699; font-weight:bold">out</code> <code style="color:#000000">
removedClient);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">ClearConnections()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">lock</code>
<code style="color:#000000">(_clients)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">_clients =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
ConcurrentDictionary&lt;Tuple&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt;, ClientConnection&gt;();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ClientConnection</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">List&lt;ClientConnectionDetials&gt; Connections { </code>
<code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">ClientConnection()</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Connections =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
List&lt;ClientConnectionDetials&gt;();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ClientConnectionDetials</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
ConnectionId { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/Host.cs
<p style="font-size:11px">This file contains the code that starts up the <span style="font-family:Consolas; color:#5591af">
WebApp</span></p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
Host</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
IDisposable _webServer;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Start()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var url = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;PulseUrl&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_webServer = WebApp.Start(url);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Console.WriteLine(String.Format(</code><code style="color:blue">&quot;OwinSignalR notifications now running on {0}&quot;</code><code style="color:#000000">,
 url));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Stop()</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(_webServer != </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">_webServer.Dispose();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/PulseController.cs
<p style="font-size:11px">Handles all the Api requests sent to the OwinSignalR.Pulse project</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">[ApiAuthorize]</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
PulseController</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">: ApiController</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IApplicationService ApplicationService { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">PulseController() </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">StructureMap.ObjectFactory.BuildUp(</code><code style="color:#006699; font-weight:bold">this</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important">&nbsp;</span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">[HttpPost]</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">IHttpActionResult Connect(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
clientId</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
method&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">, [System.Web.Http.FromBody]</code><code style="color:#006699; font-weight:bold">object</code>
<code style="color:#000000">value</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
applicationSecret = </code><code style="color:blue">&quot;&quot;</code><code style="color:#000000">)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">try</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">InvokeClientHubMethod(token, clientId, method, value);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">Ok();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">catch</code>
<code style="color:#000000">(Exception excp)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Startup.Logger.Error(</code><code style="color:blue">&quot;Error on PulseController.Connect&quot;</code><code style="color:#000000">,
 excp);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">InternalServerError(excp);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Private Methods</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
InvokeClientHubMethod(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">string</code>
<code style="color:#000000">token</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
clientId</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
method</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">,
</code><code style="color:#006699; font-weight:bold">params</code> <code style="color:#006699; font-weight:bold">
object</code><code style="color:#000000">[] args)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext&lt;Pulse.PulseHub&gt;();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">IClientProxy clientProxy;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(String.IsNullOrEmpty(clientId))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">clientProxy = context.Clients.All;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">else</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">clientProxy = context.Clients.Clients(ConnectionManager.ActiveConnections(token, clientId).Connections.Select(x
 =&gt; x.ConnectionId).ToList());</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">clientProxy.Invoke(method, args);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/PulseHub.cs
<p style="font-size:11px">Handles all the SignalR request/connections</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">[HubAuthorize]</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
PulseHub</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">:&nbsp; Hub</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp; &nbsp;#region</code><span style="margin-left:8px!important"><code style="color:gray">Private Properties</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
Token</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">get</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var token = Context.QueryString[Constants.TOKEN_QUERYSTRING];</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(String.IsNullOrEmpty(token))</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">throw</code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
UnauthorizedAccessException(</code><code style="color:blue">&quot;Token not specified&quot;</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">token;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
ClientId</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">get</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var clientId = Context.QueryString[Common.Constants.UNIQUE_CLIENT_ID];</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(String.IsNullOrEmpty(clientId))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#006699; font-weight:bold">throw</code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
UnauthorizedAccessException(</code><code style="color:blue">&quot;ClientId not specified&quot;</code><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">clientId;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region IHub Interface</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">override</code> <code style="color:#000000">
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.Task.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks.Task">System.Threading.Tasks.Task</a> OnConnected()</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">try</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Console.WriteLine(Context.ConnectionId);</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#if DEBUG</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Startup.Logger.Info(String.Format(</code><code style="color:blue">&quot;OnConnected: Token
 {0} ClientId {1}&quot;</code><code style="color:#000000">, Token, ClientId));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endif</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">ConnectionManager.Add(Token, ClientId, Context.ConnectionId);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">catch</code>
<code style="color:#000000">(Exception excp)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Startup.Logger.Error(excp.Message);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">base</code><code style="color:#000000">.OnConnected();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&nbsp; &nbsp;}</code></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">override</code> <code style="color:#000000">
<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.Task.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks.Task">System.Threading.Tasks.Task</a> OnDisconnected(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">bool</code>
<code style="color:#000000">stopCalled)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">try</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#if DEBUG</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Startup.Logger.Info(String.Format(</code><code style="color:blue">&quot;SignalR OnDisconnected:
 Token {0} ClientId {1}&quot;</code><code style="color:#000000">, Token, ClientId));</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endif</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">ConnectionManager.Remove(Token, ClientId, Context.ConnectionId);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">catch</code>
<code style="color:#000000">(Exception excp)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Startup.Logger.Error(excp.Message);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#006699; font-weight:bold">base</code><code style="color:#000000">.OnDisconnected(stopCalled);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/Startup.cs
<p style="font-size:11px">This file contains all the startup code required for the OwinSignalR.Pulse project. It registers the WebApi Controllers and the SignalR Hubs.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
Startup</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Private Members</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
readonly</code> <code style="color:#000000">log4net.ILog _log =&nbsp;&nbsp; log4net.LogManager.GetLogger(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Reflection.MethodBase.GetCurrentMethod.aspx" target="_blank" title="Auto generated link to System.Reflection.MethodBase.GetCurrentMethod">System.Reflection.MethodBase.GetCurrentMethod</a>().DeclaringType);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Public Properties</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
log4net.ILog Logger</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">get</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#006699; font-weight:bold">return</code>
<code style="color:#000000">_log;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
Configuration(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">IAppBuilder app)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Pulse.Configuration.DependencyInjectionConfiguration.Configure();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">OwinSignalR.Data.Configuration.AutomapperConfiguration.Configure();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">log4net.Config.XmlConfigurator.Configure();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">RegsiterHubs();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">app.UseCors(CorsOptions.AllowAll);</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">app.Use&lt;StructureMapOWINMiddleware&gt;();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">app.MapSignalR();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">HttpConfiguration config =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
HttpConfiguration();</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">config.Routes.MapHttpRoute(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">name:
</code><code style="color:blue">&quot;DefaultApi&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">routeTemplate:
</code><code style="color:blue">&quot;api/{controller}/{action}/{id}&quot;</code><code style="color:#000000">,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">defaults:
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
{ id = RouteParameter.Optional }</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important">&nbsp;</span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">app.UseWebApi(config);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#region Private Methods</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
RegsiterHubs()</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">GlobalHost.DependencyResolver.Register(</code><code style="color:#006699; font-weight:bold">typeof</code><code style="color:#000000">(PulseHub),
 () =&gt; </code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
PulseHub());</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">void</code> <code style="color:#000000">
SetJsonFormatting(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">HttpConfiguration config)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
CamelCasePropertyNamesContractResolver();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">config.Formatters.JsonFormatter.UseDataContractJsonSerializer =
</code><code style="color:#006699; font-weight:bold">false</code><code style="color:#000000">;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:gray">#endregion</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Pulse/Structuremap.Owin.cs
<p style="font-size:11px">OWIN middleware that sets up the EntityFramework DbContext per request.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
StructureMapOWINMiddleware</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">:&nbsp;&nbsp; OwinMiddleware</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp; &nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">StructureMapOWINMiddleware(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">OwinMiddleware next)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">:
</code><code style="color:#006699; font-weight:bold">base</code><code style="color:#000000">(next)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#000000">async </code><code style="color:#006699; font-weight:bold">override</code>
<code style="color:#000000">Task Invoke(IOwinContext context)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">StructureMap.ObjectFactory.GetInstance&lt;IDataContext&gt;().Initialize(</code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">Data.Models.OwinSignalrDbContext());</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">await Next.Invoke(context);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</li></ul>
<h4><a name="OwinSignalR_Client"></a>OwinSignalR.Client</h4>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6332.OwinSignalR.Client.png"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6332.OwinSignalR.Client.png" alt="" style="border-width:0px; border-style:solid; width:226px"></a></p>
<ul>
<li>OwinSignalR.Client/Content/bootstrap-theme.min.cs
<p style="font-size:11px">This is the bootstrap theme css file</p>
</li><li>OwinSignalR.Client/Content/bootstrap.min.cs
<p style="font-size:11px">This is the <a href="http://getbootstrap.com/css/" target="_blank">
bootstrap</a> library css file</p>
</li><li>OwinSignalR.Client/Scripts/bootstrap.min.js
<p style="font-size:11px">This is the <a href="http://getbootstrap.com/javascript/" target="_blank">
bootstrap</a> library javascript file</p>
</li><li>OwinSignalR.Client/Scripts/jquery-2.2.0.min.js
<p style="font-size:11px">This is the <a href="https://jquery.com/" target="_blank">
jquery</a> library javascript file</p>
</li><li>OwinSignalR.Client/Scripts/jquery.signalR-2.2.0.min.js
<p style="font-size:11px">This is the <a href="http://signalr.net/" target="_blank">
SignalR</a> library javascript file</p>
</li><li>OwinSignalR.Client/Scripts/OwinSignalR.js
<p style="font-size:11px">This is the main javascript file to connect to the PulseHub</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">function</code>
<code style="color:#000000">connect(token, clientId, callbacks) {</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">$.connection.hub.stop();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">$.connection.hub.qs = {
</code><code style="color:blue">'Token'</code><code style="color:#000000">: token,
</code><code style="color:blue">'ClientId'</code><code style="color:#000000">: clientId };</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">$.connection.hub.url = signalrRoot &#43;
</code><code style="color:blue">'/signalr'</code><code style="color:#000000">;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">var</code>
<code style="color:#000000">pulseHub = $.connection.pulseHub;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">if</code>
<code style="color:#000000">(pulseHub !== </code><code style="color:#006699; font-weight:bold">null</code>
<code style="color:#000000">&amp;&amp; pulseHub !== undefined) {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">for</code>
<code style="color:#000000">(</code><code style="color:#006699; font-weight:bold">var</code>
<code style="color:#000000">i = 0; i &lt; callbacks.length; i&#43;&#43;) {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#006699; font-weight:bold">for</code>
<code style="color:#000000">(</code><code style="color:#006699; font-weight:bold">var</code>
<code style="color:#000000">method </code><code style="color:#006699; font-weight:bold">in</code>
<code style="color:#000000">callbacks[i]) {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">pulseHub.client[method] = callbacks[i][method];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:24px!important"><code style="color:#000000">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">$.connection.hub.start({ transport:
</code><code style="color:blue">'longPolling'</code> <code style="color:#000000">
});</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
<p>&nbsp;</p>
</li><li>OwinSignalR.Client/Demo.html
<p style="font-size:11px">This is the demo html page</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">head</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">title</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">title</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">meta</code>
<code style="color:#808080">charset</code><code style="color:#000000">=</code><code style="color:blue">&quot;utf-8&quot;</code>
<code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">link</code>
<code style="color:#808080">href</code><code style="color:#000000">=</code><code style="color:blue">&quot;Content/bootstrap.min.css&quot;</code>
<code style="color:#808080">rel</code><code style="color:#000000">=</code><code style="color:blue">&quot;stylesheet&quot;</code>
<code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">link</code>
<code style="color:#808080">href</code><code style="color:#000000">=</code><code style="color:blue">&quot;Content/bootstrap-theme.min.css&quot;</code>
<code style="color:#808080">rel</code><code style="color:#000000">=</code><code style="color:blue">&quot;stylesheet&quot;</code>
<code style="color:#000000">/&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">src</code><code style="color:#000000">=</code><code style="color:blue">&quot;Scripts/jquery-2.2.0.min.js&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">src</code><code style="color:#000000">=</code><code style="color:blue">&quot;Scripts/jquery.signalR-2.2.0.min.js&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">src</code><code style="color:#000000">=</code><code style="color:blue">&quot;<a href="http://localhost/">http://localhost</a>:8014/signalr/hubs&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var signalrRoot = '<a href="http://localhost/">http://localhost</a>:8014';</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">src</code><code style="color:#000000">=</code><code style="color:blue">&quot;Scripts/OwinSignalR.js&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">type</code><code style="color:#000000">=</code><code style="color:blue">&quot;text/javascript&quot;</code>
<code style="color:#808080">src</code><code style="color:#000000">=</code><code style="color:blue">&quot;<a href="https://www.gstatic.com/charts/loader.js">https://www.gstatic.com/charts/loader.js</a>&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">type</code><code style="color:#000000">=</code><code style="color:blue">&quot;text/javascript&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">google.charts.load('current', { 'packages': ['gauge'] });</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">google.charts.setOnLoadCallback(drawChart);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var chart;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var data;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">var options;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">function drawChart() {</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">data = google.visualization.arrayToDataTable([</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:68px!important"><code style="color:#000000">['Label', 'Value'],</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:68px!important"><code style="color:#000000">['Memory', 80],</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:68px!important"><code style="color:#000000">['CPU', 55],</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:68px!important"><code style="color:#000000">['Network', 68]</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">]);</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">options = {</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">width: 200, height: 700,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">redFrom: 90, redTo: 100,</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">yellowFrom: 75, yellowTo: 90,</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">minorTicks: 5</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">};</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">chart = new google.visualization.Gauge(document.getElementById('chart_div'));</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">chart.draw(data, options);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">script</code>
<code style="color:#808080">type</code><code style="color:#000000">=</code><code style="color:blue">&quot;text/javascript&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">connect('48a2000467394b008938cc77b4529e3a', 'testUser', [{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">testCallBack: function (args) {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">$('#activityFeedMessage').hide();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">$('#activityFeed').prepend('&lt;</code><code style="color:#006699; font-weight:bold">li</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;list-group-item&quot;</code><code style="color:#000000">&gt;&lt;</code><code style="color:#006699; font-weight:bold">label</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;label label-success&quot;</code><code style="color:#000000">&gt;' &#43; args.createDate &#43; '&lt;/</code><code style="color:#006699; font-weight:bold">label</code><code style="color:#000000">&gt;&lt;</code><code style="color:#006699; font-weight:bold">br</code>
<code style="color:#000000">/&gt;' &#43; args.message &#43; '&lt;/</code><code style="color:#006699; font-weight:bold">li</code><code style="color:#000000">&gt;');</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">serverLoadNetwork: function (args) {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">data.setValue(2, 1, args);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">chart.draw(data, options);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">serverLoadCPU: function (args) {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">data.setValue(1, 1, args);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">chart.draw(data, options);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">},</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">serverLoadMemory: function (args) {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">data.setValue(0, 1, args);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">chart.draw(data, options);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}]);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">script</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">style</code>
<code style="color:#808080">type</code><code style="color:#000000">=</code><code style="color:blue">&quot;text/css&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">.list-group {</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">max-height: 500px;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">overflow-y: scroll;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">style</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">head</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">body</code><code style="color:#000000">&gt;</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">nav</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;navbar navbar-default navbar-static-top&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;container&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;collapse navbar-collapse&quot;</code>
<code style="color:#808080">id</code><code style="color:#000000">=</code><code style="color:blue">&quot;bs-example-navbar-collapse-1&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">ul</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;nav navbar-nav&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">li</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;active&quot;</code><code style="color:#000000">&gt;&lt;</code><code style="color:#006699; font-weight:bold">a</code>
<code style="color:#808080">href</code><code style="color:#000000">=</code><code style="color:blue">&quot;#&quot;</code><code style="color:#000000">&gt;Demo&lt;/</code><code style="color:#006699; font-weight:bold">a</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">li</code><code style="color:#000000">&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">ul</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">nav</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;container&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;row&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;col-sm-offset-3 col-sm-6&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">id</code><code style="color:#000000">=</code><code style="color:blue">&quot;chart_div&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;col-sm-3&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;panel panel-primary&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;panel-heading&quot;</code><code style="color:#000000">&gt;Activity feed&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">div</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;panel-body&quot;</code>
<code style="color:#808080">id</code><code style="color:#000000">=</code><code style="color:blue">&quot;activityFeedMessage&quot;</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:96px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">span</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;label label-warning&quot;</code><code style="color:#000000">&gt;no activity to display&lt;/</code><code style="color:#006699; font-weight:bold">span</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:80px!important"><code style="color:#000000">&lt;</code><code style="color:#006699; font-weight:bold">ul</code>
<code style="color:#808080">class</code><code style="color:#000000">=</code><code style="color:blue">&quot;list-group&quot;</code>
<code style="color:#808080">id</code><code style="color:#000000">=</code><code style="color:blue">&quot;activityFeed&quot;</code><code style="color:#000000">&gt;&lt;/</code><code style="color:#006699; font-weight:bold">ul</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:64px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:48px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">div</code><code style="color:#000000">&gt;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">&lt;/</code><code style="color:#006699; font-weight:bold">body</code><code style="color:#000000">&gt;</code></span></div>
</div>
<p>&nbsp;</p>
</li></ul>
<h4><a name="OwinSignalR_Notificator"></a>OwinSignalR.Notificator</h4>
<p><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6574.OwinSignalR.Notificator.png"><img src="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/6574.OwinSignalR.Notificator.png" alt="" style="border-width:0px; border-style:solid; width:193px"></a></p>
<ul>
<li>NotificationHelper.cs
<p style="font-size:11px">This file contains the code that updates the &quot;Activity Feed&quot;</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
class</code> <code style="color:#000000">NotificationHelper</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
Timer _notificationTimer;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
List&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt; _possibleMessages =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
List&lt;</code><code style="color:#006699; font-weight:bold">string</code><code style="color:#000000">&gt; { {
</code><code style="color:blue">&quot;Batch process complete&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;SQL Indexes rebuild complete&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;Integrity check complete&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;Temp files deleted&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;File ready for processing&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;Server now available&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;Inactive accounts deactivated&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;Welcome emails job complete&quot;</code> <code style="color:#000000">
}, { </code><code style="color:blue">&quot;Annual renew program emails sent&quot;</code> <code style="color:#000000">
} };</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
Random&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _randomMessage&nbsp;&nbsp;&nbsp; = </code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
Random();</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Start() </code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_notificationTimer =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
Timer(OnNotificationTimerCallBack, </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">, 1000, 2500);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">OnNotificationTimerCallBack(</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">object</code>
<code style="color:#000000">state)</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var service&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
NotificationService();</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var token&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;Token&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var applicationSecret = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;ApplicationSecret&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">service.Send(token, applicationSecret,
</code><code style="color:blue">&quot;testUser&quot;</code><code style="color:#000000">, </code>
<code style="color:blue">&quot;testCallBack&quot;</code><code style="color:#000000">, </code>
<code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
TestClass</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">CreateDate&nbsp; = DateTime.Now.ToString(</code><code style="color:blue">&quot;yyyy/MM/dd
 HH:ss&quot;</code><code style="color:#000000">),</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:32px!important"><code style="color:#000000">Message&nbsp;&nbsp;&nbsp;&nbsp; = _possibleMessages.ElementAt(_randomMessage.Next(_possibleMessages.Count
 - 1))</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">});</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">Console.WriteLine(</code><code style="color:blue">&quot;Sent {0}&quot;</code><code style="color:#000000">, DateTime.Now);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
TestClass </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
CreateDate { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">string</code> <code style="color:#000000">
Message&nbsp;&nbsp;&nbsp; { </code><code style="color:#006699; font-weight:bold">get</code><code style="color:#000000">;
</code><code style="color:#006699; font-weight:bold">set</code><code style="color:#000000">; }</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</li><li>Program.cs </li><li>ServerLoadHelper.cs
<p style="font-size:11px">This file contains the code that updated the Graphs/Gauges with the fake server load data.</p>
<div class="reCodeBlock" style="border:1px solid #7f9db9; overflow-y:auto; white-space:nowrap">
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">class</code> <code style="color:#000000">
ServerLoadHelper</code></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important"><code style="color:#000000">{</code></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
Timer _serverLoadMemoryTimer; </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
Timer _serverLoadCPUTimer;</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
Timer _serverLoadNetworkTimer;</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#000000">
Random _serverLoad = </code><code style="color:#006699; font-weight:bold">new</code>
<code style="color:#000000">Random();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">public</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">Start() </code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{
</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_serverLoadMemoryTimer&nbsp; =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
Timer(OnServerLoadMemoryTimer , </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">, 1000, 1000);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_serverLoadCPUTimer&nbsp;&nbsp;&nbsp;&nbsp; =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
Timer(OnServerLoadCPUTimer&nbsp;&nbsp;&nbsp; , </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">, 1000, 1700);</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">_serverLoadNetworkTimer =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
Timer(OnServerLoadNetworkTimer, </code><code style="color:#006699; font-weight:bold">null</code><code style="color:#000000">, 1000, 2300);</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">OnServerLoadNetworkTimer(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">object</code>
<code style="color:#000000">state)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var service&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
NotificationService();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var token&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;Token&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var applicationSecret = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;ApplicationSecret&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">service.Send(token, applicationSecret,
</code><code style="color:blue">&quot;testUser&quot;</code><code style="color:#000000">, </code>
<code style="color:blue">&quot;serverLoadNetwork&quot;</code><code style="color:#000000">, _serverLoad.Next(100));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">OnServerLoadCPUTimer(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">object</code>
<code style="color:#000000">state)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var service&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
NotificationService();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var token&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;Token&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var applicationSecret = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;ApplicationSecret&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">service.Send(token, applicationSecret,
</code><code style="color:blue">&quot;testUser&quot;</code><code style="color:#000000">, </code>
<code style="color:blue">&quot;serverLoadCPU&quot;</code><code style="color:#000000">, _serverLoad.Next(100));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#006699; font-weight:bold">private</code>
<code style="color:#006699; font-weight:bold">static</code> <code style="color:#006699; font-weight:bold">
void</code> <code style="color:#000000">OnServerLoadMemoryTimer(</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#006699; font-weight:bold">object</code>
<code style="color:#000000">state)</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">{</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var service&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; =
</code><code style="color:#006699; font-weight:bold">new</code> <code style="color:#000000">
NotificationService();</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var token&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;Token&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">var applicationSecret = <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Configuration.ConfigurationManager.AppSettings.aspx" target="_blank" title="Auto generated link to System.Configuration.ConfigurationManager.AppSettings">System.Configuration.ConfigurationManager.AppSettings</a>[</code><code style="color:blue">&quot;ApplicationSecret&quot;</code><code style="color:#000000">];</code></span></span></div>
<div style="background-color:#f8f8f8"><span style="margin-left:0px!important">&nbsp;</span></div>
<div style="background-color:#ffffff"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left:16px!important"><code style="color:#000000">service.Send(token, applicationSecret,
</code><code style="color:blue">&quot;testUser&quot;</code><code style="color:#000000">, </code>
<code style="color:blue">&quot;serverLoadMemory&quot;</code><code style="color:#000000">, _serverLoad.Next(100));</code></span></span></div>
<div style="background-color:#f8f8f8"><span><code>&nbsp;&nbsp;</code><span style="margin-left:8px!important"><code style="color:#000000">}</code></span></span></div>
<div style="background-color:#ffffff"><span style="margin-left:0px!important"><code style="color:#000000">}</code></span></div>
</div>
</li></ul>
