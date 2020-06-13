using Antlr4.Runtime;
using python_to_dart.Parser;
using System;

namespace python_to_dart
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = @"""
# with_stmt: ASYNC? WITH with_item (COMMA with_item)* COLON suite

# WITH with_item COLON suite
with open(""with_stmt.py""):
    pass

# WITH with_item COMMA with_item COLON suite
with open(""with_stmt.py"") as a, open(""with_stmt.py"") as b:
    pass

# async_stmt must be inside async function
async def f():
    # ASYNC with_stmt
    async with open(""with_stmt.py"") as f:
        pass
""";

            ICharStream target = new AntlrInputStream(code);
            ITokenSource lexer = new PythonLexer(target);
            ITokenStream tokens = new CommonTokenStream(lexer);
            PythonParser parser = new PythonParser(tokens);
            parser.BuildParseTree = true;

            var result = parser.root();


        }
    }
}
