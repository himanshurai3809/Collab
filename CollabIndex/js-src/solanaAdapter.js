import { PhantomWalletAdapter } from '@solana/wallet-adapter-phantom';
import { WalletReadyState } from '@solana/wallet-adapter-base';


// Attach the adapter class to window for global access.
window.PhantomWalletAdapter = PhantomWalletAdapter;
window.WalletReadyState = WalletReadyState;