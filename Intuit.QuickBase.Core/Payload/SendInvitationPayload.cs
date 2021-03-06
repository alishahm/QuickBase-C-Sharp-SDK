﻿/*
 * Copyright © 2010 Intuit Inc. All rights reserved.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.opensource.org/licenses/eclipse-1.0.php
 */
using System;
using System.Text;
using System.Xml.Linq;

namespace Intuit.QuickBase.Core.Payload
{
    internal class SendInvitationPayload : Payload
    {
        private string _userId;
        private string _userText;

        internal SendInvitationPayload(string userid, string userText)
        {
            UserId = userid;
            UserText = userText;
        }

        internal SendInvitationPayload(string userid)
        {
            UserId = userid;
        }

        private string UserId
        {
            get { return _userId; }
            set
            {
                if (value == null) throw new ArgumentNullException("userId");
                if (value.Trim() == String.Empty) throw new ArgumentException("userId");
                _userId = value;
            }
        }

        private string UserText
        {
            get { return _userText; }
            set
            {
                if (value == null) throw new ArgumentNullException("userText");
                if (value.Trim() == String.Empty) throw new ArgumentException("userText");
                _userText = value;
            }
        }

        internal override void GetXmlPayload(ref XElement parent)
        {
            parent.Add(new XElement("userid", UserId));
            if (!string.IsNullOrEmpty(UserText))  parent.Add(new XElement("usertext", UserText));
        }
    }
}
