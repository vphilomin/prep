configs ={
  :git => {
    :provider => 'github',
    :user => 'philips-august-2014',
    :remotes => %w/fangliuwh DarrenVine picbeats iainm42 trixi1979 cbenien vijujo CADI DavidSSL marccarver jensmarschner ericb81 stift vphilomin niladri-sekhar vikram-mandyam ajitkumarbiradar dhirajnayak/,
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
