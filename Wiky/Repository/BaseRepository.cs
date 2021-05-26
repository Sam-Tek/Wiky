using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiky.Repository
{
    public abstract class BaseRepository
    {
        private Wikydb _context;

        public BaseRepository()
        {
            _context = new Wikydb();
        }

        public Wikydb Context
        {
            get { return _context; }
            set { _context = value; }
        }

    }
}