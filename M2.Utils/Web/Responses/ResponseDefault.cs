using System.Collections.Generic;
using M2.Utils.Web;

namespace M2.Utils.Web.Responses
{
    
    public class ResponseDefault
    {

        private bool _isDefaultValues;
        public IList<string> Messages {get;set;}
        public ResponseState Status   {get; private set;}
        public object Body {get;set;}
        public bool IsValidResponse() => Status == ResponseState.Success;
        
        public ResponseDefault()
        {            
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            Messages = new List<string>();
            SetSuccess("Success Operation");
            _isDefaultValues = true;
        }

        private void ClearDefaultValues() {
            if (_isDefaultValues)
            {
                Messages.Clear();
                _isDefaultValues = false;
            }                
        }

        private void ClearMessageOnNewState(ResponseState aNewState) 
        {
            if (Status != aNewState)
                Messages.Clear();
        }

        public void SetError(string msg)
        {
            ClearDefaultValues();
            ClearMessageOnNewState(ResponseState.Error);
            Status = ResponseState.Error;
            Messages.Add(msg);
        }

        public void SetRangeWarning(IList<string> msg)
        {
            foreach (var str in msg) SetWarning(str);    
        }

        public void SetDefaultError()
        {
            SetError("Fatal Fail on Server Side");
        }

        public void SetWarning(string msg)
        {
            ClearDefaultValues();
            ClearMessageOnNewState(ResponseState.Warning);
            Status = ResponseState.Warning;
            Messages.Add(msg);
        }

        public void SetSuccess(string msg)
        {
            ClearDefaultValues();
            ClearMessageOnNewState(ResponseState.Success);
            Status = ResponseState.Success;
            Messages.Add(msg);
        }
/*
        public void SetErrorSuporteTecnico()
        {
            Status = ResponseStatus.Error;
            ErrorMessage.Add("Erro para finalizar operação. Entre em contato com suporte Técnico.");
        }*/
    }
}