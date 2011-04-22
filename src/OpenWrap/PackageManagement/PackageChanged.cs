﻿using System;
using System.Collections.Generic;
using OpenWrap.PackageModel;

namespace OpenWrap.PackageManagement
{
    public delegate IEnumerable<object> PackageChanged(string repository, string name, Version version, IEnumerable<IPackageInfo> packages);
}