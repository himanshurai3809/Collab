const AdapterClass = window.PhantomWalletAdapter;
const ReadyState = window.WalletReadyState;

if (!AdapterClass) console.error("❌ PhantomWalletAdapter not found");
if (!ReadyState) console.error("❌ WalletReadyState not found");

const adapter = AdapterClass ? new AdapterClass() : null;

window.connectWallet = async () => {
    if (!window.solana?.isPhantom) {
        alert("🚨 Phantom not detected — please install it from https://phantom.app/download");
        return null;
    }
    if (adapter.readyState !== ReadyState.Installed) {
        alert("🚨 Phantom isn’t ready yet — ensure you’re on HTTPS and reload the page");
        return null;
    }
    try {
        await adapter.connect();
        return adapter.publicKey?.toString() ?? null;
    } catch (err) {
        console.error("Connect error:", err);
        return null;
    }
};

window.disconnectWallet = async () => {
    if (adapter?.connected) await adapter.disconnect();
};
