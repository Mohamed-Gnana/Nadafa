using Nadafa.SharedKernal.Domain.Entities;

namespace Nadafa.Requests.Domain.Entities
{
    public class RequestAudit: BaseEntityWithActivity
    {
        private string _title;
        private string _description;
        private string? _extraInfo;

        private RequestAudit() { }
        public RequestAudit(string title, string description, string? extraInfo = null)
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
