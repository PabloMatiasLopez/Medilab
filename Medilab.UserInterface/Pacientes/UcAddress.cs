using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Medilab.BusinessObjects.Address;
using Medilab.BusinessObjects.Configuration;
using Medilab.BusinessObjects.Utils;
using Medilab.UserInterface.Utilities;
using Medilab.UserInterface.Properties;

namespace Medilab.UserInterface.Pacientes
{
    public partial class UcAddress : UserControl
    {
        #region Properties
        //private Guid _addressId;
        private Dictionary<AddressType, Address> _addresses;
        private Guid _ownerId;
        public Guid OwnerId
        {
            set
            {
                _ownerId = value;
                btnViewArchive.Visible = _ownerId != Guid.Empty;
            }
        }

        public bool IsValid
        {
            get { return ValidateAddress(); }
        }
        #endregion

        public UcAddress()
        {
            InitializeComponent();
        }
        #region Events
        // ReSharper disable InconsistentNaming
        private void UcAddress_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            _addresses = new Dictionary<AddressType, Address>();
            LoadDropdowns();
        }
        private void cbAddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            if (_addresses.ContainsKey(addressType))
            {
                LoadDefaultAddress(_addresses[addressType]);
            }
            else
            {
                LoadDefaultAddress(null);
            }
            btnArchiveAddress.Enabled = _addresses.ContainsKey(addressType) && _addresses[addressType].Id != Guid.Empty && !_addresses[addressType].Modified; 
        }

        private void txtStreetOne_Leave(object sender, EventArgs e)
        {
            var addressType = (AddressType) Enum.Parse(typeof (AddressType), cbAddressType.Text);
            if(_addresses.ContainsKey(addressType))
            {
                CheckHasChanged(addressType);
                _addresses[addressType].StreetLineOne = txtStreetOne.Text;
                _addresses[addressType].AddressState = (State) cbAddressState.SelectedItem;
                _addresses[addressType].Type = addressType;
            }
            else
            {
                _addresses.Add(addressType, new Address(Guid.Empty)
                                                {
                                                    StreetLineOne = txtStreetOne.Text,
                                                    AddressState = (State)cbAddressState.SelectedItem,
                                                    Type = addressType
                                                });
            }
            CheckDefaulAddress(addressType);
        }

        private void address_Change(object sender, EventArgs e)
        {
            btnArchiveAddress.Enabled = false;
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            if (_addresses.ContainsKey(addressType))
            {
                CheckHasChanged(addressType);
                _addresses[addressType].City = txtCity.Text;
            }
            else
            {
                _addresses.Add(addressType, new Address(Guid.Empty)
                {
                    City = txtCity.Text,
                    Type = addressType
                });
            }
        }

        private void cbAddressState_Leave(object sender, EventArgs e)
        {
            var selectedState = (State)cbAddressState.SelectedItem;
            if (selectedState == null)
            {
                MessageBox.Show(Resources.SelectAtLeastOneState, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbAddressState.Focus();
            }
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            if (cbAddressState.SelectedItem == null)
            {
                foreach (var item in cbAddressState.Items)
                {
                    var state = (State)item;
                    if (state.Name.ToLower() == cbAddressState.Text.ToLower())
                    {
                        cbAddressState.SelectedItem = item;
                        break;
                    }
                }
            }
            if (_addresses.ContainsKey(addressType))
            {
                CheckHasChanged(addressType);
                _addresses[addressType].AddressState = (State)cbAddressState.SelectedItem;
            }
            else
            {
                _addresses.Add(addressType, new Address(Guid.Empty)
                {
                    AddressState = (State)cbAddressState.SelectedItem,
                    Type = addressType
                });
            }
        }

        private void chkIsDefault_CheckedChanged(object sender, EventArgs e)
        {
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            CheckDefaulAddress(addressType);
        }

        private void btnArchiveAddress_Click(object sender, EventArgs e)
        {
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            ArchiveAddress(addressType);
        }
        private void btnViewArchive_Click(object sender, EventArgs e)
        {
            var frmArchiveAddress = new FrmHistoryAddressList(_ownerId);
            frmArchiveAddress.StartPosition = FormStartPosition.CenterScreen;
            frmArchiveAddress.ShowDialog(this);
        }
        private void txtNumber_Leave(object sender, EventArgs e)
        {
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            if (_addresses.ContainsKey(addressType))
            {
                CheckHasChanged(addressType);
                _addresses[addressType].Number = txtNumber.Text;
            }
            else
            {
                _addresses.Add(addressType, new Address(Guid.Empty)
                {
                    Number = txtNumber.Text,
                    Type = addressType
                });
            }
        }
        private void txtOtherInformation_Leave(object sender, EventArgs e)
        {
            var addressType = (AddressType)Enum.Parse(typeof(AddressType), cbAddressType.Text);
            if (_addresses.ContainsKey(addressType))
            {
                CheckHasChanged(addressType);
                _addresses[addressType].OtherInformation = txtOtherInformation.Text;
            }
            else
            {
                _addresses.Add(addressType, new Address(Guid.Empty)
                {
                    OtherInformation = txtOtherInformation.Text,
                    Type = addressType
                });
            }
        }
        // ReSharper restore InconsistentNaming
        #endregion

        #region Methods
        private void LoadDropdowns()
        {
            //Address State
            cbAddressState.Items.Clear();
            var addressStates = State.GetList().ToArray();
            var addressStateDefault = addressStates.Where(s => s.Name == "Mendoza").First();
            cbAddressState.DataSource = addressStates;
            cbAddressState.DisplayMember = "Name";
            cbAddressState.SelectedItem = cbAddressState.Items[cbAddressState.Items.IndexOf(addressStateDefault)];
            //Address Type
            cbAddressType.Items.Clear();
            cbAddressType.Items.AddRange(Enum.GetNames(typeof(AddressType)));
            cbAddressType.Text = AddressType.Legal.ToString();
        }
        public IEnumerable<Address> GetAddress()
        {
            return (from address in _addresses where !string.IsNullOrEmpty(address.Value.StreetLineOne) select address.Value).ToList();
        }

        public void LoadAddress (IEnumerable<Address> addresses)
        {
            _addresses = new Dictionary<AddressType, Address>();
            var addressList = (List<Address>) addresses;
            if (addressList == null || addressList.Count() == 0)
            {
                txtStreetOne.Text = string.Empty;
                txtNumber.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtOtherInformation.Text = string.Empty;
                foreach (var item in cbAddressState.Items)
                {
                    var state = (State)item;
                    if (state.Name == "Mendoza")
                    {
                        cbAddressState.SelectedItem = item;
                        break;
                    }
                }
                cbAddressType.Text = AddressType.Legal.ToString();
                chkIsDefault.Checked = true;
            }
            else
            {
                foreach (var address in addressList)
                {
                    _addresses.Add(address.Type, address);
                }
                var defaultAddress = _addresses.Values.FirstOrDefault(a => a.IsDefault);
                LoadDefaultAddress(defaultAddress);
                btnArchiveAddress.Enabled = true;
            }
        }
        private void LoadDefaultAddress(Address defaultAddress)
        {
            if (defaultAddress != null)
            {
                var addressType = defaultAddress.Type;
                cbAddressType.Text = defaultAddress.Type.ToString();
                chkIsDefault.Checked = _addresses[addressType].IsDefault;
                txtStreetOne.Text = _addresses[addressType].StreetLineOne;
                txtNumber.Text = _addresses[addressType].Number;
                txtCity.Text = _addresses[addressType].City;
                txtOtherInformation.Text = _addresses[addressType].OtherInformation;
                foreach (var item in cbAddressState.Items)
                {
                    var state = (State) item;
                    if (state.Id == _addresses[addressType].AddressState.Id)
                    {
                        cbAddressState.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                txtStreetOne.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtNumber.Text = string.Empty;
                txtOtherInformation.Text = string.Empty;
                foreach (var item in cbAddressState.Items)
                {
                    var state = (State) item;
                    if (state.Name == "Mendoza")
                    {
                        cbAddressState.SelectedItem = item;
                        break;
                    }
                }
                chkIsDefault.Checked = false;
            }
        }

        private void CheckDefaulAddress(AddressType addressType)
        {
            if (_addresses.Count > 1)
            {
                if (_addresses.ContainsKey(addressType))
                {
                    if (chkIsDefault.Checked)
                    {
                        _addresses[addressType].IsDefault = true;
                        foreach (var address in _addresses)
                        {
                            if (address.Key != addressType)
                            {
                                address.Value.IsDefault = false;
                            }
                        }
                    }
                    else
                    {
                        _addresses[addressType].IsDefault = false;
                        foreach (var address in _addresses)
                        {
                            if (address.Key != addressType && address.Value.IsDefault)
                            {
                                return;
                            }
                        }
                        foreach (var address in _addresses)
                        {
                            if (address.Key != addressType)
                            {
                                address.Value.IsDefault = true;
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                if (_addresses.ContainsKey(addressType))
                {
                    _addresses[addressType].IsDefault = true;
                    chkIsDefault.Checked = true;
                }
            }
        }

        private void ArchiveAddress(AddressType addressType)
        {
            var selectedAddress = _addresses[addressType];
            selectedAddress.Archive();
            _addresses.Remove(addressType);
            if (selectedAddress.IsDefault && _addresses.Count > 0)
            {
                _addresses[_addresses.ElementAt(0).Key].IsDefault = true;
            }            
            LoadAddress(_addresses.Values.ToList());
        }

        private bool ValidateAddress()
        {
            if (_addresses.Any(address => !String.IsNullOrWhiteSpace(address.Value.StreetLineOne)))
            {
                addressErrorProvider.SetError(txtStreetOne, string.Empty);
                return true;
            }
            return Validator.RequiredFieldValidator(txtStreetOne, addressErrorProvider);
        }

        private void CheckHasChanged(AddressType addressType)
        {
            if (_addresses[addressType].StreetLineOne != txtStreetOne.Text ||
                _addresses[addressType].Number != txtNumber.Text ||
                _addresses[addressType].AddressState.Name != ((State) cbAddressState.SelectedItem).Name ||
                _addresses[addressType].OtherInformation != txtOtherInformation.Text ||
                _addresses[addressType].City != txtCity.Text)
            {
                _addresses[addressType].Modified = true;
            }
            else
            {
                _addresses[addressType].Modified = false;
            }

        }

        #endregion
    }
}
