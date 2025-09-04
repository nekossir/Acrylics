# Acrylics
### Acrylic brush and panel for WPF.
Based on [FluentWPF](https://github.com/sourcechord/FluentWPF/) and [WpfShaders](https://github.com/mdschweda/WpfShaders)

<img width="627" height="426" alt="изображение" src="https://github.com/user-attachments/assets/7cae14be-7dfb-4b37-941d-c448a6316270"/>

## How to use

```Target``` - UIElement, background, target for blur.

```Source``` - UIElement, zone of blur

### 1. Add Acrylics XAML namespace
```xaml
<Window
    xmlns:ac="clr-namespace:Acrylics;assembly=Acrylics"
    ...
    >
```

### 2. Assign ```x:Name``` to the UIElement (```Target```) that is behind the ```Source``` UIElement.
It must not be the parent (including the parent of the parent, etc.) of the ```Source```.
```xaml
<Grid x:Name="grid">
...
</Grid>
```

### 3. Set ```Source```'s Background to ```{ac:AcrylicBrush [TARGET]}```
```xaml
<Border Background="{ac:AcrylicBrush grid}"/>
```


## FluentWPF blurring issue fix

#### FluentWPF uses WPF BlurEffect, which has issues with blurring content around the edges of the window.
#### Acrylics uses the GaussianBlur shader from [WpfShaders](https://github.com/mdschweda/WpfShaders), which does not have this problem.
<div>
  <img width="35%" alt="FluentWPF window" src="https://github.com/user-attachments/assets/ab3c936c-7b2f-4d19-955e-18083e9f09f8" />
  <img width="35%" alt="Acrylics window" src="https://github.com/user-attachments/assets/ba9829a8-4798-4db6-9b28-cda1f689fbb3" />
</div>


