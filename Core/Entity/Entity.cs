using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace API.Core.Entity{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Guid Id { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public DateTime? DataAtualizacao { get; protected set; }
        public bool Ativo { get; protected set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            Ativo = true;

            ValidationResult = new ValidationResult("");
        }

        public virtual bool Validar()
        {
            return true;
        }

        public virtual void Excluir()
        {
            Ativo = false;
        }

        public virtual void Atualizar()
        {
            DataAtualizacao = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}