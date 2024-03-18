import { Cloudinary } from "@cloudinary/url-gen";
const cld = new Cloudinary({ cloud: { cloudName: 'ADIS' } });

const cld = new Cloudinary({
    cloud: {
        cloudName: 'ADIS'
    }
});
const myImage = cld.image('front_face');

// Perform the transformation.
myImage
    .effect(sepia());  // Apply a sepia effect.

// Render the image in an 'img' element.
const imgElement = document.createElement('img');
imgElement.src = myImage.toURL();