using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Products { get; set; }
        public IAuthRepository Auths { get; set; }
        public IMailContentRepo MailContents { get; set; }
        public IMailSettingRepo MailSettings { get; set; }

        public UnitOfWork(IProductRepository productRepository, IAuthRepository authRepository, IMailContentRepo mailContents, IMailSettingRepo mailSettings)
        {
            Products = productRepository;
            Auths = authRepository;
            MailContents = mailContents;
            MailSettings = mailSettings;
        }
    }
}
