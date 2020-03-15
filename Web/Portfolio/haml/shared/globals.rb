module Haml::Helpers
    def render(path)
        content = File.read(path)
        Haml::Engine.new(content).render
    end
    def nonsense_paragraph()
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed gravida
dolor et ultricies placerat. Pellentesque in lectus at augue rutrum
volutpat vel sed tellus. Donec feugiat ac nibh et pharetra. Curabitur
fringilla lacinia nisl tempus mollis. Nam semper augue et ante ornare
semper. Etiam nunc velit, pharetra eget fermentum tincidunt, lacinia
vitae sapien. Etiam quis elit tincidunt, consequat urna eget, vulputate
libero. Donec dignissim ornare porttitor. Donec id augue turpis. Morbi massa
sem, dapibus at semper in, mollis a sem. Ut eu lacus ut leo aliquam laoreet.
Integer sed ex vel erat dictum finibus sit amet id mi. Duis lorem neque,
faucibus ut laoreet eu, sodales in orci. Nam mattis mauris sit amet lectus
condimentum, in maximus massa ultrices. Fusce pharetra accumsan dui sed bibendum."
    end
    def about_page_photos()
        [
            { src: "../images/bridge.jpg", alt: "Bridge" },
            { src: "../images/green.jpeg", alt: "Greens" },
            { src: "../images/statue.jpg", alt: "Statue" },
            { src: "../images/cock.jpg", alt:"Cock" },
            { src: "../images/city.jpg", alt:"City" },
            { src: "../images/fire.jpg", alt:"Fire" }
        ]
    end
end