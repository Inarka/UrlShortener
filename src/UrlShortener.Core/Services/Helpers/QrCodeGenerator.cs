﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers
{
    internal class QrCodeGenerator : IQrCodeGenerator
    {
        public Task<byte[]> Generate(string input) => throw new NotImplementedException();
    }
}