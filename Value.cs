namespace expression {
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public abstract class Value {}

    public class VInt : Value {
        public int Value { get; }
        public VInt(int value) => Value = value;
        public override string ToString() => $"{Value}";
        public override bool Equals(object obj) {
            if (obj == null || this.GetType() != obj.GetType()) return false;
            return this.Value == ((VInt) obj).Value;
        }
        public override int GetHashCode() => Value;
    }
    public class VBool : Value {
        public bool Value { get; }
        public VBool(bool value) => Value = value;
        public override string ToString() => $"{Value}";
        public override bool Equals(object obj) {
            if (obj == null || this.GetType() != obj.GetType()) return false;
            return this.Value == ((VBool) obj).Value;
        }
        public override int GetHashCode() => Value.GetHashCode();
    }

    public class Closure : Value {
        public Environment Env { get; }
        public string Variable { get; }
        public Expr Body { get; }
        public Closure(Environment env, string variable, Expr body) => (Env, Variable, Body) = (env, variable, body);

        public override string ToString() => $"\\{Variable} -> {Body}";
    }

}