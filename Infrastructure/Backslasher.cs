﻿using System;
using System.IO;

namespace DluzynaSzkola2.Infrastructure
{
    //dodaje backslash do ścieżki
    public class Backslasher
    {
        public string PathAddBackslash(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            path = path.TrimEnd();

            if (PathEndsWithDirectorySeparator())
                return path;

            return path + GetDirectorySeparatorUsedInPath();

            bool PathEndsWithDirectorySeparator()
            {
                if (path.Length == 0)
                    return false;

                char lastChar = path[path.Length - 1];
                return lastChar == Path.DirectorySeparatorChar
                    || lastChar == Path.AltDirectorySeparatorChar;
            }

            char GetDirectorySeparatorUsedInPath()
            {
                if (path.Contains(Path.AltDirectorySeparatorChar))
                    return Path.AltDirectorySeparatorChar;

                return Path.DirectorySeparatorChar;
            }
        }
    }
}
