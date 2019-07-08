using System;

namespace Forms.Web.Models
{
    public class ErrorVM : BaseVM
    {
        public ErrorVM() : base(null) { }
        public ErrorVM(User currentUser) : base(currentUser) { }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}