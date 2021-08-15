using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Exceptions
{
    public class FileOperationException : Exception
    {
        public FileOperationException(string message) : base(message)
        {
        }

        public FileOperationException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
