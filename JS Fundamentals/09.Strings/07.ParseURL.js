function solve(args) {
  var i, len, start, end,
    protocol = '',
    server = '',
    resource = '',
    input = args[0];

  protocol = input.substring(0, input.indexOf(':'));

  start = input.indexOf('/') + 2;
  end = input.indexOf('/', start + 1);

  server = input.substring(start, end);

  resource = input.substring(end);

  console.log('protocol: ' + protocol);
  console.log('server: ' + server);
  console.log('resource: ' + resource);
}

solve(['http://telerikacademy.com/Courses/Courses/Details/239']);

/*
Write a script that parses an URL address given in the format: [protocol]://[server]/[resource]
and extracts from it the [protocol], [server] and [resource] elements.

Input

The input will consist of an array containing one string
Output

The output should be consisted of three line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input

[ 'http://telerikacademy.com/Courses/Courses/Details/239' ]
Output

protocol: http
server: telerikacademy.com
resource: /Courses/Courses/Details/239
*/