using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDapper
{
    public interface ISqlOperation
    {
        CommandType CommandType { get; }
        string Text { get; }   
        int Timeout { get; }
        object Parameters { get; set; }
    }
    public abstract class PostgresSqlOperation : ISqlOperation
    {
        private const int DEFAULT_TIMEOUT_SECONDS = 30;
        public virtual CommandType CommandType { get; } = CommandType.Text;

        public abstract string Text { get; }

        public int Timeout => DEFAULT_TIMEOUT_SECONDS;

        public object Parameters { get; set; }
    }
}
