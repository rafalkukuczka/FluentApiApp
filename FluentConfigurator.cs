using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiApp
{
    using System;
    using System.Linq.Expressions;

    public class FluentConfigurator<T>
    {
        private string _propertyName;

        public FluentConfigurator(Expression<Func<T, object>> propertyExpression)
        {
            _propertyName = GetPropertyName(propertyExpression);
            Console.WriteLine($"Konfiguruję właściwość: {_propertyName}");
        }

        public FluentConfigurator<T> HasMaxLength(int maxLength)
        {
            Console.WriteLine($"Ustawiam max długość {_propertyName} na {maxLength}");
            // tu możesz zapisać konfigurację, np. do słownika
            return this;
        }

        private string GetPropertyName(Expression<Func<T, object>> expr)
        {
            if (expr.Body is UnaryExpression unaryExpr && unaryExpr.Operand is MemberExpression memberExpr)
                return memberExpr.Member.Name;

            if (expr.Body is MemberExpression member)
                return member.Member.Name;

            throw new ArgumentException("Nie można odczytać nazwy właściwości");
        }
    }

}
