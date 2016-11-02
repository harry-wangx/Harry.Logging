
using System.Runtime.InteropServices;

namespace Harry.Logging
{
    /// <summary>
    /// 事件标识号.
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public struct EventId
    {
        private readonly int _id;
        private readonly string _name;

        public EventId(int id, string name = null)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public bool Equals(EventId other)
        {
            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return this.Id == ((EventId)obj).Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }
            else
            {
                return this.Id.ToString();
            }
        }

        public static bool operator ==(EventId left, EventId right)
        {
            return left.Id == right.Id;
        }

        public static bool operator !=(EventId left, EventId right)
        {
            return left.Id != right.Id;
        }

        public static implicit operator EventId(int value)
        {
            return new EventId(value);
        }

        public static explicit operator int(EventId value)
        {
            return value.Id;
        }
    }
}

