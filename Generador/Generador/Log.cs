using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generador
{
    class Log
    {
        public DateTime timeStimestamp;
        public String product;
        public String version;
        public String errorCode;
        public String errorMsj;
        public String errorStact; 


        public Log(DateTime t,String p ,String v,String eC,String eM,String eS)
        {
            this.product = p;
            this.timeStimestamp = t;
            this.version = v;
            this.errorCode = eC;
            this.errorMsj = eM;
            this.errorStact = eS;
        }

    }
}
