
namespace PSS.WebWithAuth.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;

    /// <summary>
    /// File utils
    /// </summary>
    public class IOUtils
    {
        /// <summary>
        /// Wrap the IO method
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>True/False</returns>
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Folder checking and creation
        /// </summary>
        /// <param name="folder">Folder path</param>
        public static void CreateFolderIfNotExists(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        /// <summary>
        /// Saves file from byte array to given path
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="content">File content</param>
        public static void SaveFile(string path, byte[] content)
        {
            File.WriteAllBytes(path, content);
        }

        /// <summary>
        /// Ensures that path ends with backslash
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>Path with backslash</returns>
        public static string AddBackslash(string path)
        {
            return path.EndsWith(Path.DirectorySeparatorChar.ToString()) ? path : path + Path.DirectorySeparatorChar;
        }
        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public static byte[] ReadFully(System.IO.Stream stream, long initialLength)
        {
            // reset pointer just in case
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }
    }
}