using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository Products { get; set; }
        public IAuthRepository Auths { get; set; }
        public IMailContentRepo MailContents { get; set; }
        public IMailSettingRepo MailSettings { get; set; }
    }
}
