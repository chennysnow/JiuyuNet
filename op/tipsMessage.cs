using System;
namespace op
{
    public class tipsMessage
    {
        private string _loginSuccess = "";
        private string _userPassError = "";
        private string _codeError = "";
        private string _codeExpired = "";
        private string _registerSucces = "";
        private string _submitSuccess = "";
        private string _opSuccess = "";
        private string _opFailed = "";
        public tipsMessage()
        {
            if (staValue.language == "cn")
            {
                _loginSuccess = "登陆成功!";
                _userPassError = "用户密码错误!";
                _codeError = "验证码错误!";
                _codeExpired = "验证码过期,请刷新!";
                _registerSucces = "注册成功!";
                _submitSuccess = "提交成功!";
                _opSuccess = "操作成功!";
                _opFailed = "操作失败!";
            }
            else
            {
                _loginSuccess = "Login Successful!";
                _registerSucces = "Register Successful!";
                _userPassError = "UserName or Password is error!!";
                _codeError = "The Code wrong!";
                _codeExpired = "The Code wrong!";
                _submitSuccess = "Submitted successfully!";
                _opSuccess = "Successful operation!";
                _opFailed = "Operation failed!!";
            }

        }
        public string opFailed
        {
            get { return _opFailed; }
        }
        public string opSuccess
        {
            get { return _opSuccess; }
        }
        public string submitSuccess
        {
            get { return _submitSuccess; }
        }
        public string registerSucces
        {
            get { return _registerSucces; }
        }
        public string loginSuccess
        {
            get { return _loginSuccess; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userPassError
        {
            get { return _userPassError; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string codeError
        {
            get { return _codeError; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string codeExpired
        {
            get { return _codeExpired; }
        }
    }
}
