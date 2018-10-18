#region Copyright Syncfusion Inc. 2001 - 2016

// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.

#endregion Copyright Syncfusion Inc. 2001 - 2016

using Microsoft.AspNet.SignalR;
using System;

namespace MVCSampleBrowser.Controllers
{
    public class ScheduleHub : Hub
    {
        public void Modify(string action, Object data)
        {
            Clients.Others.modify(action, data);
        }
    }
}