
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

        public EventId(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public EventId(string name) : this(0, name)
        {

        }

        public EventId(int id) : this(id, null)
        {

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
            if (this.Id != other.Id)
            {
                return false;
            }
            return this.Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            //使用is,性能优于使用GetType
            //if (GetType() != obj.GetType())
            //    return false;
            if (!(obj is EventId))
            {
                return false;
            }
            return this.Equals((EventId)obj);
        }

        public override int GetHashCode()
        {
            if (this.Name == null)
            {
                return this.Id;
            }
            int result = 17;
            result = result * 37 + this.Id;
            result = result * 37 + this.Name.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            if (this.Name == null)
            {
                return this.Id.ToString();
            }
            return $"[{this.Id}]{this.Name}";
        }

        public static bool operator ==(EventId left, EventId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EventId left, EventId right)
        {
            return !left.Equals(right);
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

