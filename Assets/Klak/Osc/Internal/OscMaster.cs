//
// OscKlak - OSC (Open Sound Control) extension for Klak
//
// Copyright (C) 2016 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using System;

namespace Klak.Osc
{
    /// OSC master handler
    public static class OscMaster
    {
        #region Public Members

        public static MessageHandler[] messageHandlers {
            get {
                if (_servers == null) StartServers();
                return _messageHandlers;
            }
        }

        #endregion

        #region Private Members

        static OscServer[] _servers;
        static MessageHandler[] _messageHandlers;

        static void StartServers()
        {
            _servers = new OscServer[] {
                new OscServer(7000),
                new OscServer(8000),
                new OscServer(9000)
            };

            _messageHandlers = new MessageHandler[_servers.Length];

            for (var i = 0; i < _servers.Length; i++)
            {
                _messageHandlers[i] = _servers[i].messageHandler;
                _servers[i].Start();
            }
        }

        #endregion
    }
}
