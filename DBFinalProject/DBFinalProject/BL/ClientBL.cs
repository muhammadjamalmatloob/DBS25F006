using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class ClientBL : UserBL
    {
        private int client_id { get; set; }
        private int application_id { get; set; }

        public ClientBL() { }

        public void setUserId(int userId)
        {
            this.user_id = userId;
        }

        public void setApplicationId(int application_id)
        {
            this.application_id = application_id;
        }

        public int getClientId()
        {
            return this.client_id;
        }

        public int getUserId()
        {
            return this.user_id;
        }

        public int getApplicationId()
        {
            return this.application_id;
        }

    }
}
