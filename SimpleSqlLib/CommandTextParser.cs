using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace SimpleSqlLib {

    public static class CommandTextParser {

        public static string RemoveLastTerminator(string commandText) {
            if (string.IsNullOrEmpty(commandText)) {
                throw new ArgumentNullException(nameof(commandText));
            }
            if (commandText.Last() == ';') {
                return commandText[..^1];
            }
            return commandText;
        }

        public static SqlCommand RemoveLastTerminator(SqlCommand command) {
            command.CommandText = RemoveLastTerminator(command.CommandText);
            return command;
        }
    }
}
