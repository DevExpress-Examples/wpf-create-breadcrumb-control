<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128644452/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4179)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Create a Breadcrumb Control for WPF

The Breadcrumb control allows you to reproduce the Windows File Explorer UX. This example demonstrates how to create a [WPF Breadcrumb Control](https://docs.devexpress.com/WPF/DevExpress.Xpf.Controls.BreadcrumbControl) and bind it to the `Item-Children` data relation.

```xaml
<dxco:BreadcrumbControl  ItemsSource="{Binding Items}" VerticalAlignment="Top"
                          SelectedItemPath="{Binding Value, Mode=TwoWay}"
                          DisplayMember="Name" ChildMember="Children"
                          EmptyItemText="Selected root item"/>
```
```csharp
public class Item : BindableBase {
    public string Name {
        get { return GetProperty(() => Name); }
        set { SetProperty(() => Name, value); }
    }
    public int Value {
        get { return GetProperty(() => Value); }
        set { SetProperty(() => Value, value); }
    }
    public List<Child> Children {
        get { return GetProperty(() => Children); }
        set { SetProperty(() => Children, value); }
    }
}

public class Child {
    public string Name { get; internal set; }
}
```


## Files to Review

* [MainWindow.xaml](./CS/PathEditorExample/MainWindow.xaml)
* [MainWindow.xaml.cs](./CS/PathEditorExample/MainWindow.xaml.cs)


## Documentation

* [WPF Navigation Controls](https://docs.devexpress.com/WPF/115593/controls-and-libraries/navigation-controls)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-create-breadcrumb-control&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-create-breadcrumb-control&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
