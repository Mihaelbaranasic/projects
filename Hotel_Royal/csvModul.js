const fs = require('fs');

class csvModul {
    dajPodatke = function () {
        const datoteka = fs.readFileSync('podaci/rezervacije.csv', 'utf-8');
        var redovi = datoteka.split("\n");
        var rezultat = [];
        for(var red of redovi){
            var kolone = red.split(';');
            rezultat.push(kolone);
        }
        return rezultat;
      }

      dodaj = function(rezervacija) {
		var rezervacije = this.dajPodatke();
        for (var i = 0; i < rezervacije.length; i++) {
            rezervacije[i] = rezervacije[i].join(';');
          }
        
		rezervacije.push(rezervacija);
        
		var novaRezervacija = rezervacije.join('\n');
        
		fs.writeFile('podaci/rezervacije.csv',novaRezervacija,{flag: 'w'}, (greska) => { 
			if(greska) console.log(greska);
		});
	}

  brisi = function (id) {
    const podaci = this.dajPodatke();

    if (id < 0 || id >= podaci.length) {
      console.log('Neispravan ID.');
      return null;
    }

    const obrisana = podaci.splice(id, 1)[0];
    const novaDatoteka = podaci.reduce((rezultat, red) => {
      return rezultat + Object.values(red).join(';') + '\n';
    }, '');

    fs.writeFile('podaci/rezervacije.csv', novaDatoteka, 'utf-8', (greska) => {
      if (greska) console.error('Greška pri brisanju.');
    });

    return obrisana;
  }

  azuriraj = function (id, noviPodaci) {
    const podaci = this.dajPodatke();

    if (id < 0 || id >= podaci.length) {
      console.log('Neispravan ID.');
      return;
    }

    podaci[id] = noviPodaci;
    const novaDatoteka = podaci.reduce((rezultat, red) => {
      return rezultat + Object.values(red).join(';') + '\n';
    }, '');

    fs.writeFile('podaci/rezervacije.csv', novaDatoteka, 'utf-8', (greska) => {
      if (greska) console.error('Greška pri ažuriranju.');
    });
  }
}

module.exports = csvModul;
