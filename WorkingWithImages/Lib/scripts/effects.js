document.addEventListener("DOMContentLoaded", () => {

    // Set the alt tag for each image based a mapper, alternative to the code based on dashes in file name.
    setImageAlt(document);

    readJsonFile('Categories.json');


    /*
     * Provides the ability to add outlines to every single element on a page
     * Usage: Pass true to toggle for development environment, false for other environments
     * To invoke, press ALT+CTRL+1 which toggles adding/removing debugger.css
    */
    document.addEventListener('keydown', function (event) {

        if (event.key === '1' && event.altKey && event.ctrlKey) {
            // this is for development environment
            $debugHelper.toggle(true);
        }

    });



});

