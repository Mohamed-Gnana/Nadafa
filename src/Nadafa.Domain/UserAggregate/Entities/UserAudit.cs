using Nadafa.SharedKernal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Domain.UserAggregate.Entities
{
    public class UserAudit: BaseEntityWithActivity
    {
        private string _title;
        private string _description;
        private string? _extraInfo;

        private UserAudit() { }
        public UserAudit(string title, string description, string? extraInfo = null)
        {
            _title = title;
            _description = description;
            _extraInfo = extraInfo;
        }

        public string Title
        {
            get => _title;
            private set => _title = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public string? ExtraInfo
        {
            get => _extraInfo;
            private set => _extraInfo = value;
        }
    }
}
