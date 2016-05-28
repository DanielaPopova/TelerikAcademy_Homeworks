using System;

class ParseURL
{
    static void Main()
    {
        string link = Console.ReadLine(); //"http://telerikacademy.com/Courses/Courses/Details/212"

        int protocolIndex = link.IndexOf("//");       
        string protocol = link.Substring(0, protocolIndex - 1);

        int serverIndex = link.IndexOf("/", protocolIndex + 2);
        string server = link.Substring(protocolIndex + 2, serverIndex - protocolIndex - 2);

        string resource = link.Substring(serverIndex);

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);
    }
}

/*
Description

Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.

Input

On the only line you will receive an address
Output

Print the protocol, server and resource as shown below
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                        Output
http://telerikacademy.com/Courses/Courses/Details/212	        [protocol] = http
                                                                [server] = telerikacademy.com
                                                                [resource] = /Courses/Courses/Details/212
https://github.com/gentoo/gentoo.git
                                                                [protocol] = https
                                                                [server] = github.com
                                                                [resource] = /gentoo/gentoo.git

*/

