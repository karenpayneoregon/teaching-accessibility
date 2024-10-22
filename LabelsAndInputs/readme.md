# About

This project focuses on [associating labels to inputs](https://www.w3.org/WAI/WCAG21/Techniques/html/H44).

<style type="text/css">
	img[alt=thumbNail] { width: 350px; }
</style>

## Styles

## Javascript

## floatingLabels.html

An example of [floating labels](https://getbootstrap.com/docs/5.0/forms/floating-labels/). The labels are inside the input fields and when the user clicks on the input field the label floats to the top of the input field. This is a common design pattern for forms.

> **Note**
> This should only be used were space is limited.

## Basic.html

- `Top set` uses no visible label, instead uses a hidden label to keep compliant. Without the hidden label there would be two errors indicating there are missing labels. The reasoning is there is no space for visible labels.
- `Middle set` is conventional, label on top of input and works best in responsive design. Also easy to get alignment correct. If instead, using the final set and have aria help to the right of the password input responsive design would take a hit in that without using multiple media queries the help text would fold under the password label rather than the password input.
- `Bottom set` is considered the old convention for obtaining input. A common mistake here is having labels and inputs with breathing space between the two which can be challenging as per the image below, some users can only see between the fingers. Also, this can be challenging for a developer to get alignment correct. In the code an extra effort was needed to get alignment correct regarding right aligning labels.

[<img src="assets/Figure1.png" alt="thumbNail"/>](assets/Figure1.png)

## Associate labels with inputs.

A label on its own isn't much use for a screen reader. We need to tell a screen reader which input / control a label belongs to.

While it is perfectly valid to use `implicit labels`:

```html
<label>First Name
  <input name="first-name" placeholder="e.g. Toni">
</label>
```

[Certain dictation / voice control software does not work with implicit labels](https://a11ysupport.io/tech/html/label_element)!

As such you should use explicit labels (or what I like to call "old school labels"):

```html
<label for="firstName">First Name</label>
<input name="first-name" placeholder="e.g. Toni" id="firstName">
```

Where you associate the label with the input using `for="IDofInput"`.

There is an added bonus with correctly associated labels (using either method), you can click them and it focuses the corresponding input. This increases the clickable area to focus an input.

## Labels should be visually next to inputs.

Your label should be nice and close to the input it labels.

Having a lot of white space between a label and the input it is linked to can be problematic for people who use a Screen Magnifier.

One way to know how this feels is "the straw test". Close your fist until there is a gap the width of a straw left open.

Now hold your hand up to one eye and look through the tiny opening.

This will give you an idea of how much of the screen someone using a screen magnifier can see at once.

This is also the same for someone who has a condition that causes "tunnel vision", where only a small part of their visual field provides useful vision. There are a lot of other vision impairments that limit the field of vision so arrange related items so they are close together.


![Figure2](assets/figure2.png)