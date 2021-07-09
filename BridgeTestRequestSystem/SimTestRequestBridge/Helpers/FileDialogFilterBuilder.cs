using System;
using System.Collections.Generic;
using System.Text;

namespace FileDialogFilterBuilder
{
    /// <summary>
    /// Builds filter string for file dialogs.
    /// </summary>
    public class FileDialogFilterBuilder
    {
        private List<FilterInfo> infos = new List<FilterInfo>();
        /// <summary>
        /// List of informations for file filtering.
        /// </summary>
        public List<FilterInfo> Infos
        {
            get { return this.infos; }
        }

        private string NormalizeExtension(string extension)
        {
            string ret = extension;
            if (string.IsNullOrEmpty(ret) == false)
            {
                ret = ret.Trim();
                if (ret.StartsWith("*."))
                {
                    if (ret.Length > 2) { ret = ret.Substring(2); }
                    else { ret = string.Empty; }
                }
                ret = ret.Replace("|", "").Replace("(", "").Replace(")", "").Replace(";", "");
            }

            return ret;
        }

        /// <summary>
        /// Builds filter string.
        /// </summary>
        public string ToFilterString()
        {
            StringBuilder ret = new StringBuilder();

            for (int i = 0; i < this.infos.Count; i++)
            {
                FilterInfo info = this.infos[i];

                if (i > 0) { ret.Append('|'); }
                ret.Append(info.Title).Append(' ');

                string[] visibleExtensions = info.VisibleExtensions;
                int len = visibleExtensions != null ? visibleExtensions.Length : -1;
                if (len > 0)
                {
                    ret.Append('(');
                    for (int a = 0; a < len; a++)
                    {
                        if (a > 0) { ret.Append(", "); }
                        string extension = this.NormalizeExtension(visibleExtensions[a]);
                        ret.Append("*.").Append(extension);
                    }
                    ret.Append(")|");
                }
                else
                {
                    ret.Append('|');
                }

                string[] extensions = info.Extensions;
                len = extensions != null ? extensions.Length : -1;
                if (len > 0)
                {
                    for (int a = 0; a < len; a++)
                    {
                        if (a > 0) { ret.Append(';'); }
                        string extension = this.NormalizeExtension(extensions[a]);
                        ret.Append("*.").Append(extension);
                    }
                }
            }

            return ret.ToString();
        }

        /// <summary>
        /// Add filter info for "all file types".
        /// </summary>
        /// <param name="title">Title of filter.</param>
        public void AddAllFileTypes(string title)
        {
            FilterInfo info = new FilterInfo(title);
            info.Extensions = new string[] { "*" };

            this.infos.Add(info);
        }
    }

    /// <summary>
    /// Specify one item in file filter syntax
    /// </summary>
    public struct FilterInfo
    {
        private string title;
        /// <summary>
        /// Title of filter item.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        private string[] visibleExtensions;
        /// <summary>
        /// Array of extensions show to the user.
        /// </summary>
        public string[] VisibleExtensions
        {
            get { return this.visibleExtensions; }
            set { this.visibleExtensions = value; }
        }

        private string[] extensions;
        /// <summary>
        /// Array of extension used for file filtering.
        /// </summary>
        public string[] Extensions
        {
            get { return this.extensions; }
            set { this.extensions = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title">Title of filter item.</param>
        public FilterInfo(string title)
        {
            this.title = title;
            this.extensions = null;
            this.visibleExtensions = null;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title">Title of filter item.</param>
        /// <param name="extensions">Array of file extensions.</param>
        public FilterInfo(string title, params string[] extensions) : this(title)
        {
            this.SetExtenstions(extensions);
        }

        /// <summary>
        /// Copy extensions to Extension and VisibleExtensions property.
        /// </summary>
        /// <param name="arr_Extensions">Array of file extensions.</param>
        public void SetExtenstions(params string[] arr_Extensions)
        {
            string[] visibleExtensions, extensions;

            if (arr_Extensions != null)
            {
                int len = arr_Extensions.Length;
                visibleExtensions = new string[len];
                extensions = new string[len];

                arr_Extensions.CopyTo(visibleExtensions, 0);
                arr_Extensions.CopyTo(extensions, 0);
            }
            else
            {
                visibleExtensions = extensions = null;
            }

            this.VisibleExtensions = visibleExtensions;
            this.Extensions = extensions;
        }
    }
}
