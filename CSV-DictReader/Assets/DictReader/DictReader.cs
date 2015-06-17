﻿/*
 * Copyright (c) 2015, Roger Lew (rogerlew.gmail.com)
 * Date: 6/16/2015
 * License: BSD (3-clause license)
 * 
 * The project described was supported by NSF award number IIA-1301792
 * from the NSF Idaho EPSCoR Program and by the National Science Foundation.
 * 
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace VTL.IO
{
    /// <summary>
    ///  Reads .csv files using from a Unity resource location
    ///  Oject is modeled after Python's csv.DictReader and contains
    ///  an IEnumerator yielding Dictionary<string, string> objects
    ///  containing header keys and values from the row
    /// </summary>
    public class DictReader : IEnumerable
    {
        string[] header;
        List<Dictionary<string, string>> _lines;

        public static string LoadTextResource(string resourceLocation)
        {
            // Using Resources.Load to try to make this standalone/multi-platform friendly
            TextAsset theTextFile = Resources.Load<TextAsset>(resourceLocation);

            if (theTextFile == null)
            {
                Debug.LogError("Could not open text resource:" + resourceLocation);
                return string.Empty;
            }

            return theTextFile.text;

        }

        public DictReader(string resourceLocation, char delimiter = ',')
        {
            char[] sep = new char[] { delimiter };

            string text = LoadTextResource(resourceLocation);
            string[] lines = text.Split(new char[] { '\n' });

            string[] header = lines[0].Split(sep);

            for (int j = 0; j < header.Length; j++)
                header[j] = header[j].Trim();

            _lines = new List<Dictionary<string, string>>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(sep);

                if (tokens.Length != header.Length)
                {
                    var error = string.Format("DictReader Parsing Error: Expecting {0} cells, found {1}, on line {2} or {3}",
                                              header.Length, tokens.Length, i + 1, lines.Length);
                    Debug.LogError(error);
                    continue;
                }

                _lines.Add(new Dictionary<string, string>());
                for (int j = 0; j < header.Length; j++)
                {
                    _lines[i - 1].Add(header[j], tokens[j]);
                }
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public DictReaderEnum GetEnumerator()
        {
            return new DictReaderEnum(_lines);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator. 
    public class DictReaderEnum : IEnumerator
    {
        public List<Dictionary<string, string>> _lines;

        // Enumerators are positioned before the first element 
        // until the first MoveNext() call. 
        int position = -1;

        public DictReaderEnum(List<Dictionary<string, string>> list)
        {
            _lines = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _lines.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Dictionary<string, string> Current
        {
            get
            {
                try
                {
                    return _lines[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}