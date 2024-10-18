# About

Using `<a href="#TOP">&nbsp;</a>` is how many developers perform the "Back to Top" functionality. 

Since the `#` is a fragment identifier, when used will show in the URL.

Since the majority of users have JavaScript enabled, we can use JavaScript to scroll to the top of the page without the need to show the fragment identifier in the URL.

## How to use

Assign a click event, in this case to a button.

Note `behavior` can be set to `smooth` for a smooth scroll but better to simply get to top or bottom of the page.

```javascript
document.getElementById("backHome").addEventListener("click", function () {
    window.scrollTo({ top: 0, behavior: 'instant' });
});
document.getElementById("toBottom").addEventListener("click", function () {
    window.scrollTo({ top: document.body.scrollHeight, behavior: 'instant' });
});
```

## Randon text

Lorem Ipsum [generator](https://github.com/fffilo/lorem-ipsum-js)

