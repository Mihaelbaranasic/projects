//const express = require('C:\\Users\\38599\\AppData\\Roaming\\npm\\node_modules\\express'); //moj lokalni node server
const express = require('/usr/lib/node_modules/express'); //server sa vježbi
const portovi = require("/var/www/OWT/2023/portovi.js");
const server = express();
const port = portovi.mbaranasi21;
const putanja = __dirname;
const csvModul = require('./csvModul.js');
const csv = new csvModul();
const ds = require("fs");

server.use(express.urlencoded({extended: true}));
server.use(express.json());

server.delete('/api/rezervacije/:id', (zahtjev, odgovor) => {
  odgovor.type("json");
  let id = zahtjev.params.id;
  let obrisaniPodatak = csv.brisi(id);
  
  if (obrisaniPodatak === null) {
    odgovor.status(404);
    odgovor.send(JSON.stringify({ poruka: "Neispravan ID" }));
    return;
  }
  
  odgovor.status(200);
  odgovor.send(JSON.stringify({ poruka: "Podatak obrisan" }));
});

server.post('/api/rezervacije/:id', (zahtjev, odgovor) => {
  odgovor.status(405).json({ error: 'metoda nije dopuštena' });
});

server.put('/api/rezervacije/:id', (zahtjev, odgovor) => {
  odgovor.status(501).json({ error: 'metoda nije implementirana' });
});

server.get("/api/rezervacije/:id", (zahtjev, odgovor) => {
  odgovor.type("json");
  let podaci = csv.dajPodatke();
  let id = zahtjev.params.id;

  if (podaci === undefined) {
    odgovor.status(417);
    poruka = { poruka: "Greška kod učitavanja podataka" };
    odgovor.send(JSON.stringify(poruka));
    return;
  }

  if (id < 0 || id >= podaci.length) {
    odgovor.status(404);
    poruka = { poruka: "Nema resursa" };
    odgovor.send(JSON.stringify(poruka));
    return;
  }

  odgovor.status(200);
  odgovor.send(JSON.stringify(podaci[id]));
});


server.get('/api/rezervacije', (zahtjev, odgovor) => {
  const podaci = csv.dajPodatke();

  if (!podaci) {
    return odgovor.status(417).json({ error: 'Greška kod učitavanja podataka' });
  }

  odgovor.status(200).json(podaci);
});

server.post('/api/rezervacije', (zahtjev, odgovor) => {
  const zapis = zahtjev.body;

  if (!zapis || Object.keys(zapis).length === 0) {
    return odgovor.status(417).json({ error: 'nevaljani podaci' });
  }

  csv.dodaj(zapis);
  odgovor.status(200).json({ message: 'podaci dodani' });
});

server.put('/api/rezervacije', (zahtjev, odgovor) => {
  odgovor.status(501).json({ error: 'metoda nije implementirana' });
});

server.delete('/api/rezervacije', (zahtjev, odgovor) => {
  odgovor.status(501).json({ error: 'metoda nije implementirana' });
});

console.log(putanja);

server.get(/^\/(index)?$/, (zahtjev, odgovor) => {
    odgovor.sendFile(putanja + "/html/index.html");
});
server.get("/kontakt", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/html/kontakt.html");
});
server.get("/ponuda1", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/html/ponuda1.html");
});
server.get("/ponuda2", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/html/ponuda2.html");
});
server.get("/ponuda3", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/html/ponuda3.html");
});
server.get("/rezervacija", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/html/rezervacija.html");
});
server.get("/dokumentacija", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/dokumentacija/dokumentacija.html");
});
server.get("/autor", (zahtjev, odgovor) => {
  odgovor.sendFile(putanja + "/dokumentacija/autor.html");
});
server.get("/javascript", (zahtjev, odgovor)=>{
  odgovor.sendFile(putanja + "/jsk/mbaranasi21.js")
});

server.use("/css", express.static(putanja + "/css"));
server.use("/dokumenti", express.static(putanja + "/dokumenti"));
server.use("/html", express.static(putanja + "/html"));
server.use("/dokumentacija", express.static(putanja + "/dokumentacija"));

server.get("/dinamicna", (zahtjev, odgovor)=>{
  console.log("Dinamična stranica!");
  let zag = ds.readFileSync("podaci/zaglavlje.txt", "utf-8");
  let pod = ds.readFileSync("podaci/podnozje.txt", "utf-8");
  let podaci = ds.readFileSync("podaci/cjenik.json", "utf-8");
  podaci = JSON.parse(podaci);
  odgovor.type("html");
  odgovor.write(zag);
  for(let dio of podaci){
    odgovor.write("<tr>");
    odgovor.write("<td>"+dio.Naziv+"</td><td>"+dio.Opis+"</td><td>"+dio.Dan+"</td><td>"+dio.Vrijeme+"</td><td>"+dio.Cijena+"</td></tr>");
  }
  odgovor.write(pod);
  odgovor.end();
});

server.use((zahtjev, odgovor) => {
    odgovor.status(404);
    odgovor.send("Stranica nije pronađena! <a href='/'>Povratak na početnu stranicu</a>");
  });
  
  server.listen(port, () => {
    console.log(`Server pokrenut na portu: ${port}`);
  })
  