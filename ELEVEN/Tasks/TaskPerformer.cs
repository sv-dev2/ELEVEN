using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.Tasks
{
    #region Types

    public class TaskPerformer
    {
        #region Public Members

        public string C_CLASS_NAME = "TaskPerformer";

        #endregion Public Members

        #region Private Members

        private Supervisor supervisor;

        #endregion Private Members

        #region Constructors

        public TaskPerformer(Supervisor supervisorParam)
        {
            //main = mainParam;
            supervisor = supervisorParam;
        }

        #endregion Constructors
    }

    #endregion Types
}
