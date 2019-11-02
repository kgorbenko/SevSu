window.onload = () => {
    let photoWrapper = document.getElementsByClassName('photo-wrapper').item(0);
    photos.forEach(photo => {
        let img = document.createElement('img');
        img.setAttribute('src', photos[index]);
        img.setAttribute('alt', 'photoalbum photo');
        photoWrapper.appendChild(img);
    });
};

const photos : string[] = [
    'picachu.jpg',
    'images.jpeg',
    'lion-king.jpg',
    'road.jpeg',
    'car.png',
    'bridge.jpg',
    'green.jpeg',
    'statue.jpg',
    'cock.jpg',
    'city.jpg',
    'fire.jpg',
    'rose.jpeg',
    'photo.jpg',
    'castrle.jpg',
    'shimpanze.jpg',
].map(image => image = `../images/${image}`);