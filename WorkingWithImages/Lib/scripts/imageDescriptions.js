/*-----------------------------------------------------------------------
 * Code to set the alt tag for images based on a map or file name.
 -----------------------------------------------------------------------*/


/*
 * Set images alt tag based on a map.
 * This is an alternate to code in setImageAltByFileName
 *
 * @param {Document} document
 */
function setImageAlt(document) {

    const imageMapper = new Map([
        ['cityImage', "Cinque Terre Liguria"],
        ['van', "Karen's van on the run"]
    ]);

    const links = document.querySelectorAll('img');
   
    links.forEach(image => {
        const identifier = image.getAttribute('id');
        if (imageMapper.has(identifier)) {
            image.alt = imageMapper.get(identifier);
        }
    });

}

/*
 * The following code sets the alt tag for each image based on the file name
 * which is only good with decent file names.
 *
 * Replace the - with a space which works when there is a known business rule
 * and this needs to be tested to ensure it works as expected.
 *
 * Although this works, see setImageAlt above.
 */
function setImageAltByFileName(document) {

    const images = document.querySelectorAll('img');

    images.forEach(image => {
        const id = image.id;
        image.alt = document.getElementById(id).src.split('/')
            .pop().split('.')[0].replace(/-/g, ' ');
    });

}