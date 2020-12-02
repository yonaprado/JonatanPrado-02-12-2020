using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTest.Entities
{
    public class Photo
    {
        private int _albumId;
        private int _Id;
        private string _title;
        private string _url;
        private string _thumbnailUrl;

        public int AlbumId { get => _albumId; set => _albumId = value; }
        public int Id { get => _Id; set => _Id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Url { get => _url; set => _url = value; }
        public string ThumbnailUrl { get => _thumbnailUrl; set => _thumbnailUrl = value; }
    }
}