# Restsharp.Get.AddObjectParameter - Feature rich `RestSharp.RestRequest.AddObject`

# [Nuget](https://www.nuget.org/packages/Restsharp.Get.AddObjectParameter)

   `PM> Install-Package Restsharp.Get.AddObjectParameter`

# Features

 - [non public properties as parameter](https://github.com/tchelidze/Restsharp.Get.AddObjectParameter/blob/master/Restsharp.Get.AddObjectParameter.Spec/when_parameter_with_public_and_included_non_public_properties_is_passed.cs)
 - [Custom value formatting](https://github.com/tchelidze/Restsharp.Get.AddObjectParameter/blob/master/Restsharp.Get.AddObjectParameter.Spec/when_parameter_with_custom_formatted_public_properties_is_passed.cs) 
 - [Custom parameter names](https://github.com/tchelidze/Restsharp.Get.AddObjectParameter/blob/master/Restsharp.Get.AddObjectParameter.Spec/when_parameter_with_custom_named_properties_is_passed.cs)
 - [Excluding public properties from parameter list](https://github.com/tchelidze/Restsharp.Get.AddObjectParameter/blob/master/Restsharp.Get.AddObjectParameter.Spec/when_parameter_with_excluded_public_properties_is_passed.cs)
 - [Default values for parameter](https://github.com/tchelidze/Restsharp.Get.AddObjectParameter/blob/master/Restsharp.Get.AddObjectParameter.Spec/when_parameter_with_properties_with_default_values_is_passed.cs)
 
 # Example
 
 ```c#
 public class ObjectParameterWithPublicPropertiesOnly
 {
     //  Parameter { Name : "SimplePublicProperty" , Value : "Value33" }
     public string SimplePublicProperty { get; } = "Value33";

     //  Parameter { Name : "ExplicitlyIncludedPrivateProperty" , Value : "2.343" }
     [IncludeParameter]     
     private double ExplicitlyIncludedPrivateProperty { get; } = 2.343;

     //  Property will be excluded from parameter list
     [ExcludeParameter]
     public bool ExplicitlyExcludedPrivateProperty { get; } = true;
     
     //  Parameter { Name : "FormattedPublicProperty" , Value : "52.03" }
     [ParameterFormatString("F")]
     public double FormattedPublicProperty { get; } = 52.02947819434;

     //  Parameter { Name : "PropertywithDefaultValue" , Value : "Dracula" }
     [ParameterDefaultValue("Dracula")]
     public string PropertywithDefaultValue { get; } = null;
     
     //  Parameter { Name : "CustomFormattableProperty" , Value : "Formatted as SomeFormatString" }
     [ParameterFormatString("SomeFormatString")]
     public FormattableObject CustomFormattableProperty { get; } = new FormattableObject();

     public class FormattableObject
     {
        public string ToString(string format) => $"Formatted as {format}";
     }
}

 var request = new RestRequest("resource/{id}", Method.POST); 
 request.AddObjectParameter(new ObjectParameterWithPublicPropertiesOnly());
 ```
