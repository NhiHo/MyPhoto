using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPhotoAlbum
{
    class Photo : IDisposable
    {
        private string fileName;
        public string FileName
        {
            get { return this.fileName; }
        }
        private Bitmap bitmap;
        public Bitmap Image
        {
            get
            {
                if (bitmap == null)
                {
                    bitmap = new Bitmap(fileName);
                }
                return bitmap;
            }
        }
        public Photo(string fileName)
        {
            this.fileName = fileName;
            this.bitmap = null;
            this.caption = System.IO.Path.GetFileNameWithoutExtension(fileName);
        }
        private string caption = "";
        public string Caption
        {
            get { return this.caption; }
            set
            {
                if (caption != value)
                {
                    caption = value;
                    HasChanged = true;
                }
            }
        }

        private string photographer = "";
        public string Photographer
        {
            get { return this.photographer; }
            set
            {
                if (photographer != value)
                {
                    photographer = value;
                    HasChanged = true;
                }
            }
        }

        private DateTime dateTaken = DateTime.Now;
        public DateTime DateTaken
        {
            get { return this.dateTaken; }
            set
            {
                if (dateTaken != value)
                { 
                    dateTaken = value;
                    HasChanged = true;
                }
            }
        }

        private string notes = "";
        public string Notes
        {
            get { return this.notes; }
            set
            {
                if (notes != value)
                {
                    notes = value;
                    HasChanged = true;
                }
            }
        }

        private bool hasChanged = true;
        public bool HasChanged
        {
            get { return this.hasChanged; }
            internal set { hasChanged = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj is Photo)
            {
                Photo p = (Photo)obj;

                return (FileName.Equals(p.FileName, StringComparison.InvariantCultureIgnoreCase));
            }
            return false;
        }
        public void ReleaseImage()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
        }

        public void Dispose()
        {
            ReleaseImage();
        }

        public override int GetHashCode()
        {
            return FileName.
            ToLowerInvariant().GetHashCode();
        }
        public override string ToString()
        {
            return FileName;
        }
    }
}
