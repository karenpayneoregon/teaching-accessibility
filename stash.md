# Helpers
_______________________________________________________________________

```javascript
document.documentElement.setAttribute('lang', 'en');
document.documentElement.setAttribute('lang', 'es');

$x('//a')

```

## Disable all links on a page

This can be helpful for demonstration purposes.

```javascript
<script>
    document.addEventListener("DOMContentLoaded", () => {
        disableLinks();
    });
    function disableLinks () {
        const links = document.querySelectorAll('a');

        links.forEach(link => {
            link.addEventListener('click', (event) => {
                event.preventDefault();
            });
        });
    }
</script>
```
---
> [!TIP]
> Helpful advice for doing things better or more easily.

> [!IMPORTANT]
> Key information users need to know to achieve their goal.

> [!WARNING]
> Urgent info that needs immediate user attention to avoid problems.

> [!CAUTION]
> Advises about risks or negative outcomes of certain actions.
---

```javascript
/*
 * set all hyperlinks to open on a new page
 */
function setTargetBlank() {
    const links = document.querySelectorAll('a');

    links.forEach(link => {
        link.setAttribute('target', '_blank');
    });
}
```
---

