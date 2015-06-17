
CSV-DictReader
===============================

Provides a CSV interface for Unity/C# modelled after Python's csv.DictReader 
class. More specifically it assumes the first row specifies header information
and provides an IEnumerator yielding a dictionary for every (non-header) row in 
the csv file. Each dictionary contains keys corresponding to the header 
fields and values corresponding to the fields of the row.


Example Getting Started
-----------------------

Assume you have the following data in a csv format in a file within your assets
folder Assets\Resources\people\data.csv:
    FIRSTNAME,LASTNAME,AGE,STATE
    Bob,Jones,43,Iowa
    Sally,Fitzgerald,32,Nebraska
    Frederick,Smith,122,Maine
    Thomas,Yeager,23,Utah

  
The following MonoBehaviour could then be used to read the contents:
> using UnityEngine;
> using System.Collections;
> 
> using VTL.IO;
> 
> public class DictReaderTest : MonoBehaviour
> {
>     // specify the location of your csv file relative to a Resources folder
>     // leave off the extension
>     public string resourceLocation = "people/data"; 
> 
>     void Start()
>     {
>         DictReader dictReader = new DictReader(resourceLocation);
>         foreach (var row in dictReader)
>             Debug.Log(row["FIRSTNAME"] + ", " + row["LASTNAME"] + ", " + 
>                       row["AGE"] + ", " + row["STATE"]);
>     }
> }

  
Acknowledgements and Authorship (where possible)
------------------------------------------------
Author: Roger Lew (rogerlew@gmail.com)

This material is based in part upon work supported by: The National Science 
Foundation under grant number IIA-1301792. Any opinions, findings, and 
conclusions or recommendations expressed in this material are those of the 
author(s) and do not necessarily reflect the views of the National Science 
Foundation.


License
-------
This software is licensed under the BSD 3-Clause License

Copyright (c) 2015, University of Idaho, Virtual Technology Laboratory,
                    Roger Lew (rogerlew@gmail.com)
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, 
are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this 
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, 
   this list of conditions and the following disclaimer in the documentation 
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors 
   may be used to endorse or promote products derived from this software without 
   specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR 
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES 
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON 
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (
INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
