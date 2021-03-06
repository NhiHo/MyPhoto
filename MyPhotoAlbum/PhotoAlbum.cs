﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoAlbum
{
    class PhotoAlbum : Collection<Photo>, IDisposable
    {
        private bool hasChanged = false;
        public bool HasChanged
        {
            get
            {
                if (hasChanged) return true;

                foreach (Photo p in this) if (p.HasChanged) return true;

                return false;
            }

            internal set
            {
                hasChanged = value; if (value == false)
                {
                    foreach (Photo p in this) p.HasChanged = false;
                }
            }

        }
        public Photo Add(string fileName)
        {
            Photo p = new Photo(fileName);
            base.Add(p);
            return p;
        }
        public void Dispose()
        {
            foreach (Photo p in this) p.Dispose();
        }


        protected override void ClearItems()
        {
            if (Count > 0)
            {
                Dispose();
                base.ClearItems();
                HasChanged = true;
            }
        }


        protected override void InsertItem(int index, Photo item)
        {
            base.InsertItem(index, item);
            HasChanged = true;
        }


        protected override void RemoveItem(int index)
        {
            Items[index].Dispose();
            base.RemoveItem(index);
            HasChanged = true;
        }

        protected override void SetItem(int index, Photo item)
        {
            base.SetItem(index, item);
            HasChanged = true;
        }
    }
}



