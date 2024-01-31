using System;
using System.Collections.Generic;
using System.Text;
using Theater;

namespace QueryService
{
    internal interface IRequest
    {
        static public ResponseRequest<T>? GetResponseRequest<T>(Request request, ThSy database) => null;
    }
}
