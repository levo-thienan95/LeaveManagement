﻿using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.AccessControl;

namespace LeaveManagement.Domain;

public class LeaveType
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}