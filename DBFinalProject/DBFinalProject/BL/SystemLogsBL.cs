using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Cms;

namespace DBFinalProject.BL
{
    internal class SystemLogsBL
    {
        private int log_id;
        private string user_id;
        private string log_level;
        private Time log_time;
        private string action;
        private string details;

        public SystemLogsBL(int log_id, string user_id, string log_level, Time log_time, string action, string details)
        {
            this.log_id = log_id;
            this.user_id = user_id;
            this.log_level = log_level;
            this.log_time = log_time;
            this.action = action;
            this.details = details;
        }
        public SystemLogsBL() { }
        
        public int getLogId()
        {
            return log_id;
        }
        public string getUserId()
        {
            return user_id;
        }
        public string getLogLevel()
        {
            return log_level;
        }
        public Time getLogTime()
        {
            return log_time;
        }
        public string getAction()
        {
            return action;
        }
        public string getDetails()
        {
            return details;
        }
        public void setLogId(int log_id)
        {
            this.log_id = log_id;
        }
        public void setUserId(string user_id)
        {
            this.user_id = user_id;
        }
        public void setLogLevel(string log_level)
        {
            this.log_level = log_level;
        }
        public void setLogTime(Time log_time)
        {
            this.log_time = log_time;
        }
        public void setAction(string action)
        {
            this.action = action;
        }
        public void setDetails(string details)
        {
            this.details = details;
        }

    }
}
