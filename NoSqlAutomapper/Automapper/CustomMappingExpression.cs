using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace NoSqlAutomapper.Automapper
{
    public interface ICustomMappingExpression<TSource, TDestination>
    {
        CustomMapingExpressionData<TSource, TDestination> Data { get; set; }
    }

    /*public class CustomMappingExpression : IMappingExpression, ICustomMappingExpression
    {
        private IMappingExpression mappingExpression;

        public CustomMappingExpression(IMappingExpression mappingExpression)
        {
            this.mappingExpression = mappingExpression;
        }

        public void ConvertUsing<TTypeConverter>()
        {
            mappingExpression.ConvertUsing<TTypeConverter>();
        }

        public void ConvertUsing(Type typeConverterType)
        {
            mappingExpression.ConvertUsing(typeConverterType);
        }

        public void As(Type typeOverride)
        {
            mappingExpression.As(typeOverride);
        }

        public IMappingExpression WithProfile(string profileName)
        {
            mappingExpression.WithProfile(profileName);
        }

        public IMappingExpression ForMember(string name, Action<IMemberConfigurationExpression> memberOptions)
        {
            return mappingExpression.ForMember(name, memberOptions);
        }

        public CustomMapingExpressionData Data { get; set; }
    }*/

    public class CustomMappingExpression<TSource, TDestination> : IMappingExpression<TSource, TDestination>, ICustomMappingExpression<TSource, TDestination>
    {
        private IMappingExpression<TSource, TDestination> mappingExpression;

        public CustomMappingExpression(IMappingExpression<TSource, TDestination> mappingExpression)
        {
            this.mappingExpression = mappingExpression;
            this.Data = new CustomMapingExpressionData<TSource, TDestination>();
        }

        public IMappingExpression<TSource, TDestination> ForMember(Expression<Func<TDestination, object>> destinationMember, Action<IMemberConfigurationExpression<TSource>> memberOptions)
        {
            return this.mappingExpression.ForMember(destinationMember, memberOptions);
        }

        public IMappingExpression<TSource, TDestination> ForMember(string name, Action<IMemberConfigurationExpression<TSource>> memberOptions)
        {
            return this.mappingExpression.ForMember(name, memberOptions);
        }

        public void ForAllMembers(Action<IMemberConfigurationExpression<TSource>> memberOptions)
        {
            this.mappingExpression.ForAllMembers(memberOptions);
        }

        public IMappingExpression<TSource, TDestination> Include<TOtherSource, TOtherDestination>() where TOtherSource : TSource where TOtherDestination : TDestination
        {
            return this.mappingExpression.Include<TOtherSource, TOtherDestination>();
        }

        public IMappingExpression<TSource, TDestination> WithProfile(string profileName)
        {
            return this.mappingExpression.WithProfile(profileName);
        }

        public void ConvertUsing(Func<TSource, TDestination> mappingFunction)
        {
            this.mappingExpression.ConstructUsing(mappingFunction);
        }

        public void ConvertUsing(ITypeConverter<TSource, TDestination> converter)
        {
            this.mappingExpression.ConvertUsing(converter);
        }

        public void ConvertUsing<TTypeConverter>() where TTypeConverter : ITypeConverter<TSource, TDestination>
        {
            this.mappingExpression.ConvertUsing<TTypeConverter>();
        }

        public IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction)
        {
            return this.mappingExpression.BeforeMap(beforeFunction);
        }

        public IMappingExpression<TSource, TDestination> BeforeMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>
        {
            return this.mappingExpression.BeforeMap<TMappingAction>();
        }

        public IMappingExpression<TSource, TDestination> AfterMap(Action<TSource, TDestination> afterFunction)
        {
            return this.mappingExpression.AfterMap(afterFunction);
        }

        public IMappingExpression<TSource, TDestination> AfterMap<TMappingAction>() where TMappingAction : IMappingAction<TSource, TDestination>
        {
            return this.mappingExpression.AfterMap<TMappingAction>();
        }

        public IMappingExpression<TSource, TDestination> ConstructUsing(Func<TSource, TDestination> ctor)
        {
            return this.mappingExpression.ConstructUsing(ctor);
        }

        public IMappingExpression<TSource, TDestination> ConstructUsing(Func<ResolutionContext, TDestination> ctor)
        {
            return this.mappingExpression.ConstructUsing(ctor);
        }

        public void As<T>()
        {
            this.mappingExpression.As<T>();
        }

        public IMappingExpression<TSource, TDestination> MaxDepth(int depth)
        {
            return this.mappingExpression.MaxDepth(depth);
        }

        public IMappingExpression<TSource, TDestination> ConstructUsingServiceLocator()
        {
            return this.mappingExpression.ConstructUsingServiceLocator();
        }

        public IMappingExpression<TDestination, TSource> ReverseMap()
        {
            return this.mappingExpression.ReverseMap();
        }

        public IMappingExpression<TSource, TDestination> ForSourceMember(Expression<Func<TSource, object>> sourceMember, Action<ISourceMemberConfigurationExpression<TSource>> memberOptions)
        {
            return this.mappingExpression.ForSourceMember(sourceMember, memberOptions);
        }

        public CustomMapingExpressionData<TSource, TDestination> Data { get; set; }
    }
}
